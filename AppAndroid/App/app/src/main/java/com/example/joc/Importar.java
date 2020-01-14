package com.example.joc;

import com.google.gson.Gson;
import com.google.gson.reflect.TypeToken;
import java.io.BufferedReader;
import java.io.File;
import java.io.FileReader;
import java.io.IOException;
import java.util.List;

public class Importar {

    /*RUTAS A LOS FICHEROS JSON E IMAGENES*/
    public static final String SEPARADOR = File.separator;
    public static final String DIRECTORIO_CONTENIDO_ = "/sdcard/Download/contingut del joc";
    public static final String RUTA_PLANETAS = DIRECTORIO_CONTENIDO_ + SEPARADOR + "planetas" + SEPARADOR + "planetas.JSON";
    public static final String RUTA_PJS = DIRECTORIO_CONTENIDO_ + SEPARADOR + "personatges" + SEPARADOR + "personatges.JSON";
    public static final String DIRECTORIO_IMAGENES = DIRECTORIO_CONTENIDO_ + SEPARADOR + "personatges" + SEPARADOR + "imatges";


    // Lista de planetas
    private static List<Planeta> planetas;
    // Lista de personajes
    private static List<Personaje> personajes;


    public static List<Planeta> getPlanetas() {
        return planetas;
    }

    public static List<Personaje> getPersonajes() {
        return personajes;
    }

    // Lee y deserializa los planeta.JSON y personajes.JSON y los guarda en listas (planteas / personajes)
    public boolean leerContenido() {

        boolean lecturaCorrecta = false;

        Gson gson = new Gson();

        try {

            // Lectores
            BufferedReader lectorPlanetas = new BufferedReader(new FileReader(RUTA_PLANETAS));
            BufferedReader lectorPjs      = new BufferedReader(new FileReader(RUTA_PJS));

            // Deserializa y asigna a los atributos
            planetas   = gson.fromJson(lectorPlanetas, new TypeToken<List<Planeta>>(){}.getType());
            personajes = gson.fromJson(lectorPjs,      new TypeToken<List<Personaje>>(){}.getType());


            lecturaCorrecta = true;

        } catch (IOException e) {
        }
        return lecturaCorrecta;
    }


}



