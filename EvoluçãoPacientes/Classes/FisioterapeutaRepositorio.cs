using System;
using System.Collections.Generic;
using EvoluçãoPacientes.Interfaces;

namespace EvoluçãoPacientes

{
    public class FisioterapeutaRepositorio : IRepositorio<Fisioterapeuta>
    {
        private List<Fisioterapeuta> listaFisio = new List<Fisioterapeuta>();
        public void atualiza(int id, Fisioterapeuta objeto)
        {
            listaFisio[id] = objeto;
        }

        public void excluir(int id)
        {
            listaFisio[id].excluir();
        }

        public void insere(Fisioterapeuta objeto)
        {
            listaFisio.Add(objeto);
        }

        public List<Fisioterapeuta> Lista()
        {
            return listaFisio;
        }

        public int proximoId()
        {
            return listaFisio.Count;
        }

        public Fisioterapeuta retornaPorId(int id)
        {
            return listaFisio[id];
        }
    }
}