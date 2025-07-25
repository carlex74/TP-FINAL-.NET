﻿using System.Text.RegularExpressions;

namespace Domain.Model
{
    public class Especialidad: BusinessEntity
    {
        public string Descripcion { get; private set; }
        public int Id { get; private set; }

        public Especialidad(int id,string descripcion) : base()
        {
            Id = id;
            SetDescripcion(descripcion);
        }

        public void SetDescripcion(string descripcion)
        {
            if (string.IsNullOrWhiteSpace(descripcion))
                throw new ArgumentException("La descripción no puede ser nula o vacía.", nameof(descripcion));
            Descripcion = descripcion;
        }
    }
}
