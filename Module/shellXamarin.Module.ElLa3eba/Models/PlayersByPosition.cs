using System.Collections.Generic;

namespace shellXamarin.Module.ElLa3eba.Models
{
    public class PlayersByPosition : List<Player>
    {
        public string Position { get; private set; }
        public PlayersByPosition(string position, IEnumerable<Player> players)
        {
            if (players != null)
                this.AddRange(players);
            Position = position;
        }
    }
}
