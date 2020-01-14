package com.example.joc;


import android.app.Activity;
import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.TextView;

import java.util.List;

public class Adaptador extends BaseAdapter {


    private List<Respuesta> respuestas;
    private Activity context;

    public Adaptador(Activity _context,List<Respuesta> _respuestas) {

        context = _context;
        respuestas = _respuestas;
    }


    public View getView(int position, View convertView, ViewGroup parent) {

        View view = convertView;
        if (view == null){
            LayoutInflater li = (LayoutInflater) context
                    .getSystemService(Context.LAYOUT_INFLATER_SERVICE);
            view = li.inflate(R.layout.place_respuesta, null);
        }

        final TextView respuesta = view.findViewById(R.id.placerespuesta);
        respuesta.setText(respuestas.get(position).getRespuesta());

        return view;
    }

    @Override
    public int getCount() {
        int retorno = 0;

        if(respuestas != null)
            retorno = respuestas.size();

        return retorno;
    }

    @Override
    public Object getItem(int i) {
        return null;
    }

    @Override
    public long getItemId(int i) {
        return i;
    }

}
