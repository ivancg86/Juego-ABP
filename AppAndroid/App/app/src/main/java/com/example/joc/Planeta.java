package com.example.joc;

import java.util.ArrayList;
import java.util.List;

public class Planeta {

    //en el juego existen 3 planetas, como hay 3 idiomas obtenemos un total de 9 planetas.
    //las id 0-2 son los 3 planetas en catalan, 3-5 en castellano y del 6-8 en ingles
    private byte id;
    //variable que contendra el contenido del planeta importado posteriorment del json
    private String contenido;
    //lista con las preguntas del planeta
    private List<Pregunta> preguntas;
    private byte idioma;

    //getters
    public byte getId() {
        return id;
    }

    public String getContenido() {
        return contenido;
    }

    public List<Pregunta> getPreguntas() {
        return  preguntas;
    }

}
