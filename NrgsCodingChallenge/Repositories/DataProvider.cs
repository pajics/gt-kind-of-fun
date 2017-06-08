using System.Collections.Generic;
using NrgsCodingChallenge.Models;

namespace NrgsCodingChallenge.Repositories
{
    public interface IDataProvider
    {
        Player GetById(int id);
        Player GetByEmail(string emailornick);
        Player GetByNick(string emailornick);
    }

    class DataProvider : IDataProvider
    {
        private readonly IDictionary<int, Player> _playersById;
        private readonly IDictionary<string, Player> _playersByEmail;
        private readonly IDictionary<string, Player> _playersByNick;

        public DataProvider()
        {
            var player = new Player(
                42,
                "Doe",
                "John",
                new Address("Infinite Loop", "1/1/2", "1234", "Los Angeles", "Californication"),
                "john.doe@example.com",
                "jodo");

            _playersById = new Dictionary<int, Player> { { player.Id, player } };
            _playersByEmail = new Dictionary<string, Player> { { player.Email, player } };
            _playersByNick = new Dictionary<string, Player> { { player.NickName, player } };
        }

        public Player GetById(int id)
        {
            if (_playersById.ContainsKey(id))
            {
                return _playersById[id];
            }

            return null;
        }

        public Player GetByEmail(string emailornick)
        {
            if (_playersByEmail.ContainsKey(emailornick))
            {
                return _playersByEmail[emailornick];
            }

            return null;
        }

        public Player GetByNick(string emailornick)
        {
            if (_playersByNick.ContainsKey(emailornick))
            {
                return _playersByNick[emailornick];
            }

            return null;
        }
    }
}