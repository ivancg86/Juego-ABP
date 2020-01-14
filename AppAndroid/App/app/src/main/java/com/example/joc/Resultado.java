package com.example.joc;

import androidx.appcompat.app.AppCompatActivity;
import androidx.core.content.res.FontResourcesParserCompat;

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

public class Resultado extends AppCompatActivity {

    private final static int CATALAN = 4;
    private final static int ESPANOL = 8;
    private final static int INGLES = 10;

    //variable para guardar el numero de aciertos total
    private static int aciertos = 0;

    public static void reiniciarAciertos() {
        aciertos = 0;
    }

    //metodo para actualizar el numero de aciertos
    public static void sumarAcierto() {
        aciertos++;
    }



    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_resultado);

        // Elimina la transición
        overridePendingTransition(0, 0);

        // Esconde la UI del sistema
        hideSystemUI();

        //recuperamos los id del xml de los 3 views siguientes
        TextView aciertosView = findViewById(R.id.aciertos);
        ImageButton salir = findViewById(R.id.inicio);
        ImageView personaje =findViewById(R.id.personaje);


        //recoge de la pantalla principal el planeta seleccionado
        Intent intentDoble = getIntent();
        int planetaMostrado = intentDoble.getIntExtra("planetaMostrado", 0);

        //creamos un personaje y le asignamos el nombre con el metodo getPersonajes de la clase Importar
        Personaje personaje1 = new Personaje();
        personaje1.setNom(Importar.getPersonajes().get(0).getNom());

        //mostraremos el personaje 1 si el usuario consigue menos de 3 aciertos
        if(aciertos < 3)
        {
            //CARGA imagen1.png DEL DIRECTORIO imatges Y LO COLOCA EN EL imageview
            String fname = new File(Importar.DIRECTORIO_IMAGENES, "imagen1.png").getAbsolutePath();
            Bitmap myBitmap = BitmapFactory.decodeFile(fname);
            personaje.setImageBitmap(myBitmap);
            mostrarPersonaje(planetaMostrado, 1);

        }
        //mostraremos el personaje 2 si el usuario consigue menos de 7 aciertos
        else if (aciertos < 7)
        {
            //CARGA imagen2.png DEL DIRECTORIO imatges Y LO COLOCA EN EL imageview
            String fname = new File(Importar.DIRECTORIO_IMAGENES, "imagen2.png").getAbsolutePath();
            Bitmap myBitmap = BitmapFactory.decodeFile(fname);
            personaje.setImageBitmap(myBitmap);


            mostrarPersonaje(planetaMostrado,2);
        }
        //mostraremos el personaje 3 si el usuario consigue 7 o más aciertos
        else
        {
            //CARGA imagen3.png DEL DIRECTORIO imatges Y LO COLOCA EN EL imageview
            String fname = new File(Importar.DIRECTORIO_IMAGENES, "imagen3.png").getAbsolutePath();
            Bitmap myBitmap = BitmapFactory.decodeFile(fname);
            personaje.setImageBitmap(myBitmap);

            mostrarPersonaje(planetaMostrado,3);
        }

        aciertos++;

        //mostramos por pantalla el numero de aciertos total
        aciertosView.setText(getString(R.string.numAciertos)+ " " + String.valueOf(aciertos) );

        //reiniciamos el numero de aciertos
        aciertos = 0;


        //creamos un temporizador al que le pasamos por parametro lo que va a durar en las unidades especificadas en el segundo parametro, en este caso milisegundos
        //el temporizador lleva al usuario al inicio del juego tras 30 segundos
        final TextView tiempo = findViewById(R.id.tiempo);
        new CountDownTimer(Dificultad.TEMPORIZADOR, Dificultad.INTERVALO_TEMPORIZADOR) {

            public void onTick(long millisUntilFinished) {
                tiempo.setText("seconds remaining: " + millisUntilFinished / 1000);
            }

            public void onFinish() {
                // envia result_OK y Cierra esta actividad
                setResult(Resultado.RESULT_OK);
                // Vuelve al main
                finish();
            }
        }.start();




        salir.setOnClickListener(new View.OnClickListener(){
            @Override
            public void onClick(View v) {

                // envia result_OK y Cierra esta actividad
                setResult(Resultado.RESULT_OK);
                aciertos = 0;
                finish();
            }
        });
    }

    //metodo para mostrar el personaje segun el idioma mostrado para cargar el contenido en el idioma adecuado
    private void mostrarPersonaje(int planetaMostrado, int personaje){

        //recogemos los id del xml
        TextView nombre = findViewById(R.id.nombre);
        TextView frase = findViewById(R.id.frase);

        //planetas en catalan 0-2
        if (planetaMostrado < CATALAN)
        {
            //segun el personaje que se tenga que mostrar dependiendo de los aciertos, cargaremos su contenido en catalan
            switch (personaje) {
                case 1:
                    nombre.setText(Importar.getPersonajes().get(0).getNom());
                    frase.setText(Importar.getPersonajes().get(0).getFrase());
                    break;
                case 2:
                    nombre.setText(Importar.getPersonajes().get(1).getNom());
                    frase.setText(Importar.getPersonajes().get(1).getFrase());
                    break;
                case 3:
                    nombre.setText(Importar.getPersonajes().get(2).getNom());
                    frase.setText(Importar.getPersonajes().get(2).getFrase());
                    break;
            }
        }
        //planetas en castellano
        else if(planetaMostrado < ESPANOL)
        {
            //segun el personaje que se tenga que mostrar dependiendo de los aciertos, cargaremos su contenido en español
            switch (personaje) {
                case 1:
                    nombre.setText(Importar.getPersonajes().get(3).getNom());
                    frase.setText(Importar.getPersonajes().get(3).getFrase());
                    break;
                case 2:
                    nombre.setText(Importar.getPersonajes().get(4).getNom());
                    frase.setText(Importar.getPersonajes().get(4).getFrase());
                    break;
                case 3:
                    nombre.setText(Importar.getPersonajes().get(5).getNom());
                    frase.setText(Importar.getPersonajes().get(5).getFrase());
                    break;
            }

        }
        //planetas en ingles
        else if(planetaMostrado < INGLES)
        {
            //segun el personaje que se tenga que mostrar dependiendo de los aciertos, cargaremos su contenido en ingles
            switch (personaje) {

                case 1:
                    nombre.setText(Importar.getPersonajes().get(6).getNom());
                    frase.setText(Importar.getPersonajes().get(6).getFrase());
                    break;
                case 2:
                    nombre.setText(Importar.getPersonajes().get(7).getNom());
                    frase.setText(Importar.getPersonajes().get(7).getFrase());
                    break;
                case 3:
                    nombre.setText(Importar.getPersonajes().get(8).getNom());
                    frase.setText(Importar.getPersonajes().get(8).getFrase());
                    break;
            }
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
