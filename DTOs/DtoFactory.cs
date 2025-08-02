using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class DtoFactory
    {
        public Object CreateDto(string dto)
        {
            switch (dto)
            {
                case "EspecialidadDTO":
                    return new EspecialidadDTO();
                // Add more DTO types here as needed
                default:
                    throw new ArgumentException($"DTO type '{dto}' is not recognized.");
            }
        }

    }
}
