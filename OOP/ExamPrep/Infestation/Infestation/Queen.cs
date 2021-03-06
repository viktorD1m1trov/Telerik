﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    class Queen : Unit
    {
        private const int QueenHealth= 30;
        private const int QueenPower = 1;
        private const int QueenAggression = 1;
        public Queen(string id) : base(id, UnitClassification.Psionic, QueenHealth, QueenPower, QueenAggression)
        {
            this.AddSupplement(new InfestationSpores());
        }
        protected override UnitInfo GetOptimalAttackableUnit(IEnumerable<UnitInfo> attackableUnits)
        {
            UnitInfo optimalAttackableUnit = new UnitInfo(null, UnitClassification.Unknown, 0, int.MaxValue, 0);

            foreach (var unit in attackableUnits)
            {
                if (unit.Health < optimalAttackableUnit.Health)
                {
                    optimalAttackableUnit = unit;
                }
            }

            return optimalAttackableUnit;
        }
        public override Interaction DecideInteraction(IEnumerable<UnitInfo> units)
        {
            IEnumerable<UnitInfo> attackableUnits = units.Where((unit) => this.CanAttackUnit(unit)).
                Where(u=>u.UnitClassification==InfestationRequirements.RequiredClassificationToInfest(this.UnitClassification));
            
            UnitInfo optimalAttackableUnit = GetOptimalAttackableUnit(attackableUnits);

            if (optimalAttackableUnit.Id != null)
                
            {
                return new Interaction(new UnitInfo(this), optimalAttackableUnit, InteractionType.Attack);
            }

            return Interaction.PassiveInteraction;
        }
    }
}
