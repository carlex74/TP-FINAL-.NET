﻿using System.Text.RegularExpressions;

namespace Domain.Model
{
    public class DocenteCurso : BusinessEntity
    {
        public enum TipoCargos //por ahora solo estos tipos de cargos, se pueden agregar más si es necesario
        {
            ProfesorTitular,
            ProfesorAdjunto,
            JefeDeTrabajosPracticos,
            AyudanteDeCatedra
        }
        public TipoCargos Cargo { get; private set; }
        public int IdCurso { get; private set; }
        public int IdDocente { get; private set; }

        public DocenteCurso(TipoCargos cargo, int idCurso, int idDocente) : base()
        {
            SetCargo(cargo);
            SetIdCurso(idCurso);
            SetIdDocente(idDocente);
        }
        public void SetCargo(TipoCargos cargo)
        {
            if (!Enum.IsDefined(typeof(TipoCargos), cargo))
                throw new ArgumentException("El tipo de cargo no es válido.", nameof(cargo));
            Cargo = cargo;
        }
        public void SetIdCurso(int idCurso)
        {
            if (idCurso <= 0)
                throw new ArgumentException("El ID del curso debe ser un número positivo.", nameof(idCurso));
            IdCurso = idCurso;
        }
        public void SetIdDocente(int idDocente)
        {
            if (idDocente <= 0)
                throw new ArgumentException("El ID del docente debe ser un número positivo.", nameof(idDocente));
            IdDocente = idDocente;
        }
    }
}
