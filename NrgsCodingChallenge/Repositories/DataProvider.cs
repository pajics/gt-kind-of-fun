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

    public class DataProvider : IDataProvider
    {
        private readonly IDictionary<int, Player> _playersById = new Dictionary<int, Player>();
        private readonly IDictionary<string, Player> _playersByEmail = new Dictionary<string, Player>();
        private readonly IDictionary<string, Player> _playersByNick = new Dictionary<string, Player>();

        public DataProvider()
        {
            AddPlayers(new Player(
                42,
                "Doe",
                "John",
                new Address("Infinite Loop", "1/1/2", "1234", "Los Angeles", "Californication"),
                "john.doe@example.com",
                "jodo"));
        }

        public DataProvider(params Player[] players)
        {
            AddPlayers(players);
        }

        private void AddPlayers(params Player[] players)
        {
            foreach (var player in players ?? new Player[0])
            {
                _playersById.Add(player.Id, player);
                _playersByEmail.Add(player.Email, player);
                _playersByNick.Add(player.NickName, player);
            }
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