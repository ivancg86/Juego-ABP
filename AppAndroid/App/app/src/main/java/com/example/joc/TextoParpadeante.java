package com.example.joc;

import android.content.Context;
import android.view.animation.Animation;
import android.view.animation.AnimationUtils;
import android.view.animation.Animation.AnimationListener;
import android.widget.TextView;

public class TextoParpadeante {

    Context context;
    private TextView texto;
    private Animation fadeIn = null;
    private Animation fadeOut = null;

    // Listeners que detectan el fin de la animación
    private LocalFadeInAnimationListener myFadeInAnimationListener = new LocalFadeInAnimationListener();
    private LocalFadeOutAnimationListener myFadeOutAnimationListener = new LocalFadeOutAnimationListener();

    // Constructor que le mandamos en el ultimo parametro el TextView
    public TextoParpadeante(Context context, TextView text){
        this.context = context;
        this.texto = (TextView)text;
        runAnimations();
    }

    //Constructor que hace que empiece animacion fadeOut
    private void launchOutAnimation() {
        texto.startAnimation(fadeOut);
    }


    //Constructor que hace que empiece animacion fade-in
    private void launchInAnimation() {
        texto.startAnimation(fadeIn);
    }


    //Comienzo de la animación
    private void runAnimations() {
        //uso de las animaciones
        fadeIn = AnimationUtils.loadAnimation(this.context, R.anim.fadein);
        fadeIn.setAnimationListener( myFadeInAnimationListener );
        fadeOut = AnimationUtils.loadAnimation(this.context, R.anim.fadeout);
        fadeOut.setAnimationListener( myFadeOutAnimationListener );

        launchInAnimation();
    }

    // Runnable que arranca la animación FadeOut
    private Runnable mLaunchFadeOutAnimation = new Runnable() {
        public void run() {
            launchOutAnimation();
        }
    };

    // Runnable que arranca la animación FadeIn
    private Runnable mLaunchFadeInAnimation = new Runnable() {
        public void run() {
            launchInAnimation();
        }
    };


    //Listener para la animacion del Fadeout
    private class LocalFadeInAnimationListener implements AnimationListener {
        public void onAnimationEnd(Animation animation) {
            texto.post(mLaunchFadeOutAnimation);
        }
        public void onAnimationRepeat(Animation animation){
        }
        public void onAnimationStart(Animation animation) {
        }
    };


    //Listener de animación para el Fadein
    private class LocalFadeOutAnimationListener implements AnimationListener {
        public void onAnimationEnd(Animation animation) {
            texto.post(mLaunchFadeInAnimation);
        }
        public void onAnimationRepeat(Animation animation) {
        }
        public void onAnimationStart(Animation animation) {
        }
    };


}