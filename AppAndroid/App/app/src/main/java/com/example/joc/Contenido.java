package com.example.joc;

import androidx.appcompat.app.AppCompatActivity;
import android.content.Intent;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.os.Bundle;
import android.os.CountDownTimer;
import android.view.View;
import android.widget.Button;
import android.widget.ImageButton;
import android.widget.ImageView;
import android.widget.TextView;
import java.io.File;
import java.util.List;


public class Contenido extends AppCompatActivity {


    //variable para seleccionar la dificultad del juego
    private boolean dificultadSeleccionada;

    //variable para volver a esta pantalla una vez hemos avanzado a la siguiente
    private static final byte JUEGO_ACTIVITY = 1;

    //variable que nos mostrara el planeta en el cual nos encontramos
    private int planetaMostrado;

     // Guarda en planetas la lista de planetas del json
    private List<Planeta> planetas = Importar.getPlanetas();


    //creamos un temporizador al que le pasamos por parametro lo que va a durar en las unidades especificadas en el segundo parametro, en este caso milisegundos
    CountDownTimer contador = new CountDownTimer(Dificultad.TEMPORIZADOR, Dificultad.INTERVALO_TEMPORIZADOR) {
        @Override
        public void onTick(long l) {}

        @Override
        public void onFinish() {
            // envia result_OK y Cierra esta actividad
            setResult(Resultado.RESULT_OK);
            // Vuelve al main
            finish();
        }
    };


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_contenido);

        // Elimina la transición
        overridePendingTransition(0, 0);

        // Esconde la UI del sistema
        hideSystemUI();

        //recuperamos los id del xml de los 3 views siguientes
        Button continuar = findViewById(R.id.btncontinuar);
        ImageView imagenNarrador = findViewById(R.id.imagenNarrador);
        ImageButton inicio = findViewById(R.id.inicio);


        // Asociamos la TextView de inicio a su id
        TextView tv = (TextView) findViewById(R.id.continuar);
        // Le mandamos la TextView a la clase TextoParpadeante
        new TextoParpadeante(getBaseContext(),tv);

        //recoge de la pantalla principal y pantalla de dificultad el idioma seleccionado (es decir el planeta por el que el juego empezara)
        // y la dificultad seleccionada respectivamente.
        Intent intentDoble = getIntent();
        planetaMostrado = intentDoble.getIntExtra("planetaMostrado", 0);
        dificultadSeleccionada = intentDoble.getBooleanExtra("dificultad", false);

        //cargamos el contenido del planeta
        cargarTexto();

        //empieza la cuenta atras para enviar al usuario al menu si no hay ningun click
        contador.start();

        //CARGA imagen3.png DEL DIRECTORIO imatges Y LO COLOCA EN EL imageview
        String fname = new File(Importar.DIRECTORIO_IMAGENES, "imagen1.png").getAbsolutePath();
        Bitmap myBitmap = BitmapFactory.decodeFile(fname);
        imagenNarrador.setImageBitmap(myBitmap);

        // Botón continuar
        continuar.setOnClickListener(new View.OnClickListener() {
            @Override

            public void onClick(View v) {
                Intent intentContenido = new Intent(getApplicationContext(), Juego.class);

                intentContenido.putExtra("dificultad", dificultadSeleccionada);
                intentContenido.putExtra("planetaMostrado", planetaMostrado);
                int preguntaMostrada = 0;
                intentContenido.putExtra("preguntaMostrada", preguntaMostrada);

                // abre la activity del Juego
                contador.cancel();

                startActivityForResult(intentContenido, JUEGO_ACTIVITY);
            }
        });

        // Botón salir
        inicio.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                contador.cancel();
                // Devuelve RESULT OK a la clase Dificultad
                setResult(Contenido.RESULT_OK);
                // Cierra esta actividad
                finish();
                Resultado.reiniciarAciertos();
            }
        });

    }

    private void cargarTexto() {
        TextView informacion = findViewById(R.id.informacion);

        //EL TEXTO SE CARGA DEL PLANTA planetaMostrado
        informacion.setText(planetas.get( planetaMostrado ).getContenido() );

        mostrarProgreso();

    }

    // Resultado de startActivityForResult
    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        super.onActivityResult(requestCode, resultCode, data);

        // Si la actividad de la que volvemos
        if (requestCode == JUEGO_ACTIVITY) {

            // Y devuelve RESULT_OK
            if (resultCode == RESULT_OK) {

                // Devuelve RESULT OK a la clase Dificultad
                setResult(Contenido.RESULT_OK);

                // Cerramos esta actividad también
                finish();
            }
            // Si se ha llegado a la ultima pregunta
            else{
                // Esconde la UI del sistema
                hideSystemUI();
                // Empieza el contador
                contador.start();
                // muestra el siguiente contenido
                planetaMostrado++;
                cargarTexto();
            }
        }
    }

    private void mostrarProgreso(){

        //recuperamos el id del xml
        TextView progreso = findViewById(R.id.progreso);

        //switch para mostrar el progreso del juego
        switch (planetaMostrado){

            //si estamos en el primer planeta
            case 0:
            case 3:
            case 6:
                progreso.setText("1 / 3");
                break;

            //si estamos en el segundo planeta
            case 1:
            case 4:
            case 7:
                progreso.setText("2 / 3");
                break;

            //si estamos en el tercer planeta
            case 2:
            case 5:
            case 8:
                progreso.setText("3 / 3");
                break;


        }

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
