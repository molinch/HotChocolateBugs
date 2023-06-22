using HotChocolate;
using HotChocolate.Types;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebSocketAndPersistedQueriesBug
{
    public class Subscription
    {
        [Subscribe(With = nameof(ListenForPersons))]
        public Person OnNewPerson([EventMessage] Person person) => person;

        public async IAsyncEnumerable<Person> ListenForPersons()
        {
            var nameGenerator = new RandomNameGeneratorNG.PersonNameGenerator();
            while (true)
            {
                yield return new Person(nameGenerator.GenerateRandomFirstAndLastName());
                await Task.Delay(500);
            }
        }
    }
}
