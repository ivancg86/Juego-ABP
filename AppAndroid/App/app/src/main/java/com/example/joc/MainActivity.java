package com.example.joc;

//Imports
import android.Manifest;
import android.annotation.SuppressLint;
import android.content.Intent;
import android.content.pm.PackageManager;
import android.content.res.Configuration;
import android.content.res.Resources;
import android.media.MediaPlayer;
import android.net.Uri;
import android.os.Bundle;
import android.provider.Settings;
import android.util.DisplayMetrics;
import android.view.View;
import android.widget.ImageView;
import android.widget.RelativeLayout;
import android.widget.TextView;
import android.widget.VideoView;

import androidx.appcompat.app.AppCompatActivity;
import androidx.core.app.ActivityCompat;
import androidx.core.content.ContextCompat;
import com.google.android.material.snackbar.Snackbar;
import java.util.Locale;




public class MainActivity extends AppCompatActivity {


/*
    El juego tiene 3 planetas por cada idioma, en este caso seria:
    catalan = 0, 1, 2
    español = 3, 4, 5
    ingles = 6, 7, 8
    segun selecionado empezar por el primero de cada uno de ellos
    y ya pasamos a la pantalla de dificultad
 */

    // Idiomas
    private static final String catalan = "cat";
    private static final String espanol = "spa";
    private static final String ingles  = "eng";
    public static final int ACTIVITY_DIFICULTAD = 1;


    /*Iterador de planetas*/
    private static int planetaMostrado;
    /*Según el idioma seleccionado se empezara por un planeta u otro. Por defecto es el idioma de sistema*/
    private static String idiomaSeleccionado = Locale.getDefault().getISO3Language();



    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        hideSystemUI();

        //Se asocian ImageView a sus id que les corresponden
        ImageView cat = findViewById(R.id.catalan);
        ImageView esp = findViewById(R.id.castellano);
        ImageView eng = findViewById(R.id.ingles);
        ImageView iniciar = findViewById(R.id.btniniciar);

        // Controla que haya permisos de lectura
        controlarPermisos();


        colocarTexto();



        // Inicia el video del fondo de la pantalla de inicio
        iniciarVideo();

        // Click en INICIAR
        iniciar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                // Dependiendo del idiomaMostrado se empiza por un planeta u otro
                if (idiomaSeleccionado.equals(catalan) ){
                    planetaMostrado = 0;
                }
                else if (idiomaSeleccionado.equals(espanol)){
                    planetaMostrado = 3;
                }
                else {
                    planetaMostrado = 6;
                }

                Resultado.reiniciarAciertos();

                Intent intentPlaneta = new Intent(MainActivity.this, Dificultad.class);
                intentPlaneta.putExtra("planetaMostrado", planetaMostrado);

                // Inicia la actividad
                startActivityForResult(intentPlaneta, ACTIVITY_DIFICULTAD);
            }
        });


        // Click en catalan
        cat.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                setLocale("ca");
                planetaMostrado = 0;
                idiomaSeleccionado = catalan;
                colocarTexto();
            }
        });
        // Click en español
        esp.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                setLocale("es");
                planetaMostrado = 3;
                idiomaSeleccionado = espanol;
                colocarTexto();
            }
        });
        // Click en ingles
        eng.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                setLocale("en");
                planetaMostrado = 6;
                idiomaSeleccionado = ingles;
                colocarTexto();
            }
        });

    }

    // Coloca/refresca el texto de la pantalla según el idioma seleccionado
    private void colocarTexto() {
        // Asociamos la TextView de inicio a su id
        TextView tv = findViewById(R.id.textoIniciar);
        // Le damos el texto correspondiente
        tv.setText(getResources().getString(R.string.iniciar));
        // Le mandamos la TextView a la clase TextoParpadeante
        new TextoParpadeante(getBaseContext(),tv);
    }

    @Override
    protected void onResume(){
        super.onResume();
        // Esconde la UI del sistema
        hideSystemUI();
        // Al volver atrás recarga el metodo de iniciarVideo
        iniciarVideo();
    }

    // Controla permisos de lectura
    private void controlarPermisos() {

        // Objeto para importar
        Importar contenido = new Importar();

        // Controlem la versió d'Android que estem executant.
        if (android.os.Build.VERSION.SDK_INT >= 23)
        {
            // Si no s'ha concedit el permís de lectura
            if (ContextCompat.checkSelfPermission(this, Manifest.permission.READ_EXTERNAL_STORAGE)
                    != PackageManager.PERMISSION_GRANTED) {

                if (ActivityCompat.shouldShowRequestPermissionRationale(this,
                        Manifest.permission.READ_EXTERNAL_STORAGE)) {

                    // Obre el menu perque es donguin permissos
                    Intent intent = new Intent();
                    intent.setAction(Settings.ACTION_APPLICATION_DETAILS_SETTINGS);
                    Uri uri = Uri.fromParts("package", getPackageName(), null);
                    intent.setData(uri);
                    startActivity(intent);

                }
                else {
                    demanarPermisos();
                }
            }
            // Si s' ha concedit el permís
            else{
                // Si no se ha podido leer el contenido
                if (!contenido.leerContenido()){

                    RelativeLayout layout = findViewById(R.id.main);
                    // Instancia un snackbar
                    Snackbar snackbar = Snackbar.make(layout,"No s'ha pogut llegir el contingut del joc",Snackbar.LENGTH_LONG);
                    snackbar.show();
                }
            }
        }
        // Si executem una versió anterior a la versió Marshmallow (6.0),
        // no cal demanar cap permís, i podem executar el nostre codi directament
        else
        {
            contenido.leerContenido();
        }
    }

    // Cambia el idiomaMostrado
    private void setLocale(String lang) {

        Locale locale = new Locale(lang);
        Resources res = getResources();
        DisplayMetrics dm = res.getDisplayMetrics();
        Configuration conf = res.getConfiguration();
        conf.locale = locale;
        res.updateConfiguration(conf, dm);
    }

    // Cuando el usuario ha respondido a la solicitud de permisos en tiempo de ejecucion
    @Override
    public void onRequestPermissionsResult(int requestCode, String[] permissions, int[] grantResults) {
        switch (requestCode) {
            case ACTIVITY_DIFICULTAD: {
                // Si se han otorgado permisos
                if (grantResults.length > 0 && grantResults[0] == PackageManager.PERMISSION_GRANTED) {


                }
                // Si no
                else {
                    demanarPermisos();

                }
                return;
            }
        }
    }

    // Pide permisos de lectura al usuario
    public void demanarPermisos(){
        // Demana permissos en temps d'execució
        ActivityCompat.requestPermissions(this,
                new String[]{Manifest.permission.READ_EXTERNAL_STORAGE}, ACTIVITY_DIFICULTAD);

    }

    // Inicia el video de fondo
    private void iniciarVideo() {
        VideoView videoView = findViewById(R.id.video);

        // Establece los parametros de las dimensiones del videoView para que ocupe toda la pantalla
        DisplayMetrics metrics = new DisplayMetrics();
        getWindowManager().getDefaultDisplay().getMetrics(metrics);
        videoView.setLayoutParams(new RelativeLayout.LayoutParams(metrics.widthPixels, metrics.heightPixels));

        // Inicializa el video de la pantalla de inicio
        Uri path = Uri.parse("android.resource://com.example.joc/" + R.raw.starwarstakeoff);
        videoView.setVideoURI(path);
        videoView.start();

        // Hace que el video haga loop
        videoView.setOnPreparedListener(new MediaPlayer.OnPreparedListener() {
            @Override
            public void onPrepared(MediaPlayer mp) {
                mp.setLooping(true);
            }
        });
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


