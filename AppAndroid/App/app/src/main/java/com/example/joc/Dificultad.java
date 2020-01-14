package com.example.joc;

//Imports
import androidx.appcompat.app.AppCompatActivity;
import android.content.Intent;
import android.os.Bundle;
import android.os.CountDownTimer;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

public class Dificultad extends AppCompatActivity {

    //Variable necesaria para el intent para reconcer la actividad
    public static final int CONTENIDO_ACTIVITY = 1;

    //Boleano para la seleccion de dificultad
    private boolean dificultadSeleccionada;

    //constante de tiempo para el temporizador
    public static final int TEMPORIZADOR = 30000;

    //intervalo del temporizador
    public static final int INTERVALO_TEMPORIZADOR = 1000;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_dificultad);

        // Elimina la transición
        overridePendingTransition(0, 0);

        // Esconde la UI del sistema
        hideSystemUI();

        //Asignacion de los botones de dificultad
        Button facil = findViewById(R.id.facil);
        Button dificil = findViewById(R.id.dificil);

        //creamos el intent para cargar la activity contenido
        final Intent intentContenido = new Intent(getApplicationContext(), Contenido.class);

        Intent intentDoble = getIntent();
        int planetaMostrado = intentDoble.getIntExtra("planetaMostrado", 0);

        intentContenido.putExtra("planetaMostrado", planetaMostrado);

        //Al hacer click sobre el nivel de dificultad carga el contenido y preguntas
        facil.setOnClickListener(new View.OnClickListener(){
            @Override
            public void onClick(View v) {

                // Inicia la actividad
                dificultadSeleccionada = true;
                intentContenido.putExtra("dificultad", dificultadSeleccionada);
                startActivityForResult(intentContenido, CONTENIDO_ACTIVITY);

            }
        });

        dificil.setOnClickListener(new View.OnClickListener(){
            @Override
            public void onClick (View v){

                // Inicia la actividad
                dificultadSeleccionada = false;
                intentContenido.putExtra("dificultad", dificultadSeleccionada);
                startActivityForResult(intentContenido, CONTENIDO_ACTIVITY);

            }
        });
        //Contador de tiempo para que cuando pasa cierto tiempo se salga al menu de inicio
        new CountDownTimer(TEMPORIZADOR, INTERVALO_TEMPORIZADOR) {

            public void onTick(long millisUntilFinished) {

            }
            //Al terminar el tiempo cierra la actividad y va al main
            public void onFinish() {

                // Vuelve al main
                finish();
            }
            //Empieza el contador
        }.start();

    }

    // Resultado de startActivityForResult
    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        super.onActivityResult(requestCode, resultCode, data);

        // Si la actividad de la que volvemos
        if (requestCode == CONTENIDO_ACTIVITY) {

            // Y devuelve RESULT_OK
            if (resultCode == RESULT_OK) {

                // Devuelve RESULT OK a la clase Dificultad
                setResult(Dificultad.RESULT_OK);

                // Cerramos esta actividad también
                finish();
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
