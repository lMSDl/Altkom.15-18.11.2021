using System;

namespace WPC.Behavioral.Command
{
    public static class Client
    {
        public static void Execute()
        {
            var garden = new Garden(5);


            var plantTreeCommand = new GardenCommand(garden, "tree", GardenAction.Plant);
            var plantFlowersCommand = new GardenCommand(garden, "flowers", GardenAction.Plant);
            var removeTreeCommand = new GardenCommand(garden, "tree", GardenAction.Remove);
            var removeFlowersCommand = new GardenCommand(garden, "flowers", GardenAction.Remove);

            var plantTreeButton = new CommandsInvoker(plantTreeCommand);
            var plantFlowersButton = new CommandsInvoker(plantFlowersCommand);
            var removeTreeButton = new CommandsInvoker(removeTreeCommand);
            var removeFlowersButton = new CommandsInvoker(removeFlowersCommand);


            Console.WriteLine(garden.ToString());

            plantTreeButton.Invoke();
            plantTreeButton.Invoke();
            plantFlowersButton.Invoke();

            Console.WriteLine(garden.ToString());
            plantFlowersButton.Invoke();
            plantFlowersButton.Invoke();
            plantTreeButton.Invoke();
            Console.WriteLine(garden.ToString());
            removeFlowersButton.Invoke();
            plantTreeButton.Invoke();
            Console.WriteLine(garden.ToString());

            CommandsInvoker.Undo();
            CommandsInvoker.Undo();
            CommandsInvoker.Undo();

            Console.WriteLine(garden.ToString());

        }
    }
}
