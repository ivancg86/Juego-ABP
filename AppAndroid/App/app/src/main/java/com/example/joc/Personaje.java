package com.example.joc;

public class Personaje {

    //cada personaje tiene un nombre y una frase que se mostrara al final del juego en la pantalla Resultado
    private String nom;
    private String frase;

    //cada personaje tiene su ruta que sera static
    private static String rutaImagen1;
    private static String rutaImagen2;
    private static String rutaImagen3;

    //getters
    public String getNom() {
        return nom;
    }

    public void setNom(String nom) {
        this.nom = nom;
    }

    public String getFrase() {
        return frase;
    }


}
