﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ISoftDeletable
    {
        bool IsDeleted { get; }
        DateTime? DeletedOnUtc { get; }

        void SoftDelete();
        void Restore();
    }
}
