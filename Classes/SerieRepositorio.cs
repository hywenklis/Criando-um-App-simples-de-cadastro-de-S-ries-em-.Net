using System;
using System.Collections.Generic;
using DIO.SERIES.Interfaces;

namespace DIO.SERIES
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        private List<Serie> ListaSerie = new List<Serie>();
        public void Atualiza(int id, Serie entidade)
        {
            ListaSerie[id] = entidade;
        }

        public void Exclui(int id)
        {
            ListaSerie[id].Excluir();
        }

        public void Insere(Serie entidade)
        {
            ListaSerie.Add(entidade);
        }

        public List<Serie> Lista()
        {
            return ListaSerie;
        }

        public int ProximoId()
        {
            return ListaSerie.Count;
        }

        public Serie RetornaPorId(int id)
        {
           return ListaSerie[id];
        }
    }
}