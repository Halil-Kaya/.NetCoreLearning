using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data
{
    public class MockCommanderRepository : ICommandRepository
    {
        public IEnumerable<Command> GetAppCommands()
        {
            var commands = new List<Command>{
                new Command{Id = 1 ,HowTo = "boil an egg",Line = "boil water",Platform = "kettle & pan"},
                new Command{Id = 2 ,HowTo = "2 sadfasdf ",Line = "boil water",Platform = "kettle & pan"},
                new Command{Id = 3 ,HowTo = "3 asdga s",Line = "boil water",Platform = "kettle & pan"},
                new Command{Id = 4 ,HowTo = "4 sdfgd fg",Line = "boil water",Platform = "kettle & pan"},
            };

            return commands; 
        }

        public Command GetCommandById(int id)
        {
            return new Command{Id = 1 ,HowTo = "boil an egg",Line = "boil water",Platform = "kettle & pan"};
        }
    }
}