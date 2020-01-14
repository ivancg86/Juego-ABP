package com.example.joc;

//Imports
import java.util.List;

class Pregunta {
    //Atributos de pregunta
    private String pregunta;
    private List<Respuesta> respuestas;
    private boolean dificultad;

    //Recoge la pregunta
    public String getPregunta() {
        return pregunta;
    }

    //Lista con las respuestas de cada pregunta
    public List<Respuesta> getRespuestas() {
        return respuestas;
    }

    //Boleano para seleccion de dificutad
    public boolean isDificultad() {
        return dificultad;
    }


}
