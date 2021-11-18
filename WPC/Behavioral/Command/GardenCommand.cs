using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPC.Behavioral.Command
{
    class GardenCommand : ICommand
    {
        private Garden _garden;
        private string _plant;
        private GardenAction _gardenAction;

        public GardenCommand(Garden garden, string plant, GardenAction gardenAction)
        {
            _garden = garden;
            _plant = plant;
            _gardenAction = gardenAction;
        }

        public bool Execute()
        {
            switch (_gardenAction)
            {
                case GardenAction.Plant:
                    return _garden.Plant(_plant);
                    break;
                case GardenAction.Remove:
                    return _garden.Remove(_plant);
                    break;
            }
            return false;
        }

        public void Undo()
        {
            switch (_gardenAction)
            {
                case GardenAction.Plant:
                    _garden.Remove(_plant);
                    break;
                case GardenAction.Remove:
                    _garden.Plant(_plant);
                    break;
            }
        }
    }
}