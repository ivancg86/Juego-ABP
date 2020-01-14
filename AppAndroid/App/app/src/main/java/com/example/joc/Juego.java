package com.example.joc;

import androidx.appcompat.app.AppCompatActivity;
import android.content.Intent;
import android.graphics.Color;
import android.os.Build;
import android.os.Bundle;
import android.os.CountDownTimer;
import android.os.Handler;
import android.view.Gravity;
import android.view.View;
import android.widget.AdapterView;
import android.widget.GridView;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.RelativeLayout;
import android.widget.TextView;
import com.google.android.material.snackbar.Snackbar;
import java.util.ArrayList;
import java.util.List;

public class Juego extends AppCompatActivity {
/*
 1. Recibimos la primera pregunta a mostrar a traves de las variables:
    PlanetaMostrado y preguntaMostrada

 2. Se filtran las preguntas por dificultad con el metodo filtrarPreguntas y se guardan en preguntasFiltradas

 3. Se carga el contenido mediante el método cargarContenido()

 4. OnClick respuesta:
    Llama al método juego:
        4.1 Si hay más preguntas se muestra la siguiente y llamamos a cargarContenido()
        4.2 Si no hay más preguntas pasamos de planeta y si no quedan más planetas abrimos Resultado
*/

    // Usado iniciar la actividad resultado
    private static final byte RESULTADO_ACTIVIDAD = 1;
    // Guarada la pregunta que debe mostrarse
    private static int preguntaMostrada = 0;
    // Guarda el planeta que debe mostrarse
    private static int planetaMostrado;
    // Se usa para filtrar las preguntas según la dificultad seleccionada
    private boolean dificultadSeleccionada;
    // Guarda las preguntas filtradas
    private List<Pregunta> preguntasFiltradas = new ArrayList<Pregunta>();
    // Guarda el último planeta según el idioma seleccionado (3 planetas por idioma)
    private int  maxPlaneta = 0;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_juego);

        // Elimina la transición
        overridePendingTransition(0, 0);

        // Esconde la UI del sistema
        hideSystemUI();

        // GridView donde se mostrarán las respuestas de la pregunta
        final GridView gridrespuestas = findViewById(R.id.gridrespuestas);
        // TextView para mostrar el tiempo del contador
        final TextView contadorView = findViewById(R.id.tiempo);

        // Recoge el intent con el planeta a mostrado, la dificultad y la pregunta a mostrar
        Intent intentDoble = getIntent();
        planetaMostrado = intentDoble.getIntExtra("planetaMostrado", 0);
        dificultadSeleccionada = intentDoble.getBooleanExtra("dificultad", false);
        preguntaMostrada = intentDoble.getIntExtra("preguntaMostrada", 0);


        // Establece cuál es el último planeta según el idioma seleccionado
        establecerMaxPlaneta();

        // Contador del juego
        final CountDownTimer contador = new CountDownTimer(Dificultad.TEMPORIZADOR, Dificultad.INTERVALO_TEMPORIZADOR) {
            @Override
            public void onTick(long millisUntilFinished) {
                contadorView.setText("" + millisUntilFinished / 1000);
            }

            // Cuando el contador llega a 0 se hace un click en una respuesta incorrecta
            @Override
            public void onFinish() {

                // Si la primera respuesta es correcta se pulsa sobre la segunda
                if (preguntasFiltradas.get(preguntaMostrada).getRespuestas().get(0).isEsCorrecta()){

                    gridrespuestas.performItemClick(gridrespuestas.getChildAt(1), 0, gridrespuestas.getItemIdAtPosition(1));
                }
                // Si la primera pregunta no es correcta se pulsa sobre esta
                else{
                    gridrespuestas.performItemClick(gridrespuestas.getChildAt(0), 0, gridrespuestas.getItemIdAtPosition(0));
                }
            }
        };

        // Obtiene las todas las preguntas y llama al método filtrarPreguntas
        filtrarPreguntas( Importar.getPlanetas().get(planetaMostrado).getPreguntas() );
        // Método que carga la pregunta y las respuestas en pantalla
        cargarContenido(gridrespuestas, contador);


        // RelativeLayout usado para mostrar un SnackBar
        final RelativeLayout juegoLayout = findViewById(R.id.juegoLayout);

        // Al pulsar sobre un item del GridView
        gridrespuestas.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, final View view, int position, long id) {

                // Si la view devuelta no es nula
                if (view != null){

                    // El contador se cancela
                    contador.cancel();

                    // Se bloquea el click para evitar posibles errores
                    gridrespuestas.setEnabled(false);

                    // Se obtiene el LinearLayout correspondiente al item seleccioando
                    LinearLayout respuesta = (LinearLayout) view;

                    // Guarda TRUE si la respuesta seleccionada es correcta
                    boolean repuestaCorrecta = preguntasFiltradas.get(preguntaMostrada).getRespuestas().get(position).isEsCorrecta();

                    // Si la respuesta seleccionada es correcta
                    if(repuestaCorrecta ){

                        // Pone el fondo de la respuesta en verde
                        respuesta.getChildAt(0).setBackgroundColor(Color.parseColor("#355e4e"));
                    }
                    // Si es incorrecta
                    else{
                        // Pone el fondo de la respuesta pulsada en rojo
                        respuesta.getChildAt(0).setBackgroundColor(Color.parseColor("#5e3535"));

                        // Elemento parent casteado a GridView para buscar entre items
                        GridView grid = (GridView) parent;

                        // Recorre las respuestas de la grid en busca de la respuesta correcta
                        for (int i = 0 ; i < grid.getCount() ; i++){

                            // Cada TextView de las views de la gridView
                            TextView text = (TextView)((LinearLayout)grid.getChildAt(i)).getChildAt(0);

                            // Si la respuesta es correcta
                            if(preguntasFiltradas.get(preguntaMostrada).getRespuestas().get(i).isEsCorrecta()){

                                // Cambia el fondo de color verde
                                text.setBackgroundColor(Color.parseColor("#355e4e"));
                            }
                        }
                    }

                    // Método juego que decide si pasar a la siguiente pregunta o pasar planeta
                    juego(position , juegoLayout, gridrespuestas, contador);
                }

            }
        });

    }

    // Según el planeta seleccionado tendremos un planeta máximo distinto
        // PLANETAS CATALAN: 0,1,2
        // PLANETAS ESPAÑOL: 3,4,5
        // PLANETAS INGLÉS:  6,7,8
    private void establecerMaxPlaneta() {


        // Si el idioma seleccionado es CATALÁN
        if (planetaMostrado >= 0 && planetaMostrado <= 2){
            // El último planeta será el 2
            maxPlaneta = 2;
        }
        // Si el idioma seleccionado es ESPAÑOL
        else if(planetaMostrado >= 3 && planetaMostrado <= 5){
            // El último planeta será el 5
            maxPlaneta = 5;
        }
        // Si el idioma seleccionado es INGLÉS
        else{
            // El último planeta será el 8
            maxPlaneta = 8;
        }
    }

    // juego: Si quedan más preguntas pasa a la siguiente, sino se pasa al siguiente planeta, si no, a la actividad Resultado
    // PARÁMETROS:
        // position:       Índice de la respuesta pulsada
        // juegoLayout:    Layout donde se muestra el SnackBar
        // gridRespuestas: GridView donde se muestran las respuestas
        // contador:       Contador del juego
    private void juego(int position, RelativeLayout juegoLayout, final GridView gridRespuestas, final CountDownTimer contador ) {

        // Si quedan más preguntas por mostrar
        if ( preguntaMostrada < preguntasFiltradas.size() -1){

            // Si se ha acertado la respuesta
            if (preguntasFiltradas.get(preguntaMostrada).getRespuestas().get(position).isEsCorrecta()) {

                // Suma un acierto
                Resultado.sumarAcierto();

                // Método que muestra un snackbar
                mostrarSnackBar(juegoLayout);

                // Pausa antes de pasar a la siguiente pregunta
                Handler handler = new Handler();
                handler.postDelayed(new Runnable() {
                    public void run() {
                        gridRespuestas.setEnabled(true);
                        preguntaMostrada++;
                        cargarContenido(gridRespuestas, contador);
                    }
                }, 2000);   //2 seconds

            }
            // Si no se ha acertado la respuesta
            else{
                // Pausa antes de pasar a la siguiente pregunta
                Handler handler = new Handler();
                handler.postDelayed(new Runnable() {
                    public void run() {
                        gridRespuestas.setEnabled(true);
                        preguntaMostrada++;
                        cargarContenido(gridRespuestas, contador);
                    }
                }, 2000);   //2 seconds
            }
        }
        // Si no quedan más preguntas por mostrar
        else{

            // Si se ha acertado la respuesta
            if (preguntasFiltradas.get(preguntaMostrada).getRespuestas().get(position).isEsCorrecta()) {

                // Suma un acierto
                Resultado.sumarAcierto();
                // Muestra un snackbar
                mostrarSnackBar(juegoLayout);
            }

            // Incrementa el planeta
            planetaMostrado++;

            // Si quedan más planetas por mostrar
            if ( planetaMostrado <= maxPlaneta ){

                // Devuelve RESULT OK a la clase Dificultad
                setResult(Contenido.RESULT_FIRST_USER);

                // Metodo para que al volver empiece por la pregunta 0 del siguiente planeta
                reiniciarPreguntas();

                // Pausa antes de pasar a la siguiente pregunta
                Handler handler = new Handler();
                handler.postDelayed(new Runnable() {
                    public void run() {
                        //Cierra esta actividad
                        finish();
                    }
                }, 2000);   //2 seconds

            }
            // Muestra la Pantalla Resultado
            else{

                // Metodo para que al volver empiece por la pregunta 0 del siguiente planeta
                reiniciarPreguntas();

                // Pausa antes de pasar a la siguiente pregunta
                Handler handler = new Handler();
                handler.postDelayed(new Runnable() {
                    public void run() {

                        //Intent para pasar el planetaMostrado
                        Intent intentResultado = new Intent(getApplicationContext(), Resultado.class);
                        intentResultado.putExtra("planetaMostrado", planetaMostrado);

                        // Se abre Resultado
                        startActivityForResult(intentResultado, RESULTADO_ACTIVIDAD );
                    }
                }, 2000);   //2 seconds
            }
        }

    }

    // Método para mostrar un Snackbar al acertar una respuesta
    private void mostrarSnackBar(RelativeLayout juegoLayout) {
        // Muestra un snackbar

        // Instancia un snackbar
        Snackbar snackbar = Snackbar.make(juegoLayout,getString(R.string.respuestaCorrecta),Snackbar.LENGTH_SHORT);

        // Colores del Snackbar
        View snackbarView = snackbar.getView();
        TextView snackText =  snackbarView.findViewById(R.id.snackbar_text);

        // Color del texto
        // Dependiendo de la versión de android
        snackText.setTextColor(Color.WHITE);
        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.M){
            snackText.setTextAlignment(View.TEXT_ALIGNMENT_CENTER);
        } else {
            snackText.setGravity(Gravity.CENTER_HORIZONTAL);
        }

        // Color de fondo
        snackbarView.setBackgroundColor(Color.parseColor("#355e4e"));

        // Tamaño del texto
        snackText.setTextSize(50);

        // Tamaño del snackbar
        Snackbar.SnackbarLayout layout = (Snackbar.SnackbarLayout)snackbar.getView();
        layout.setMinimumHeight(60);//your custom height.
        layout.setMinimumWidth(400);

        // Display the Snackbar
        snackbar.show();
    }

    // carga la pregunta y las respuestas en la gridView
    // PARAMETROS:
        // gridRespuestas: GridView donde se muestran las respuestas
        // contador:       Contador del juego
    private void cargarContenido(final GridView gridRespuestas, CountDownTimer contador) {

        // Lista de respuestas de la pregunta actual
        List<Respuesta> respuestas = preguntasFiltradas.get(preguntaMostrada).getRespuestas();

        // TextView donde va la pregunta
        TextView viewPregunta = findViewById(R.id.pregunta);

        // Coloca la pregunta en el TextView
        viewPregunta.setText(preguntasFiltradas.get(preguntaMostrada).getPregunta());

        //Instancia nuestro adaptador personalizado
        Adaptador adaptador = new Adaptador(this, respuestas);

        // Establece el adaptor al GridView
        gridRespuestas.setAdapter(adaptador);

        // Inicia el contador
        contador.start();

    }

    // Método para filtrar las preguntas según la dificultad seleccioanda
    // PARAMETROS
        // preguntas: Lista con todas las preguntas
    private void filtrarPreguntas(List<Pregunta> preguntas) {

        // Si la dificultad seleccionada es fácil
        if (!dificultadSeleccionada){

            // Recorre la lista de preguntas
            for (int i = 0 ; i < preguntas.size() ; i++){

                // Si la pregunta es facil
                if (preguntas.get(i).isDificultad()){

                    // Se añade a la lista de preguntas filtradas
                    preguntasFiltradas.add( preguntas.get(i) );
                }
            }
        }
        //Dificultad de juego: Dificil
        else{

            // Recorre la lista de preguntas
            for (int i = 0 ; i <  preguntas.size() ; i++){

                // Si la pregunta es dificil
                if ( ! preguntas.get(i).isDificultad() ){

                    // Se añade a la lista de preguntas filtradas
                    preguntasFiltradas.add(preguntas.get(i) );
                }
            }
        }


    }

    // Resultado de startActivityForResult
    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        super.onActivityResult(requestCode, resultCode, data);

        // Si la actividad de la que volvemos
        if (requestCode == RESULTADO_ACTIVIDAD) {

            // Y devuelve RESULT_OK
            if (resultCode == RESULT_OK) {

                // Devuelve RESULT OK a la clase Dificultad
                setResult(Contenido.RESULT_OK);

                // Metodo para reinciar las preguntas y empezar por la primera al volver
                reiniciarPreguntas();

                // Cerramos esta actividad
                finish();
            }
        }
    }

    // Se vacía la lista de preguntas filtradas y se pone a 0 la pregunta a mostrar
    private void reiniciarPreguntas() {
        preguntasFiltradas.clear();
        preguntaMostrada = 0;
    }

    // Esconde la UI del sistema
    private void hideSystemUI() {

        View decorView = getWindow().getDecorView();
        decorView.setSystemUiVisibility(
                View.SYSTEM_UI_FLAG_IMMERSIVE_STICKY
                        | View.SYSTEM_UI_FLAG_FULLSCREEN
                        | View.SYSTEM_UI_FLAG_HIDE_NAVIGATION
                        | View.SYSTEM_UI_FLAG_LAYOUT_FULLSCREEN
                        | View.SYSTEM_UI_FLAG_LAYOUT_STABLE);
    }
}
