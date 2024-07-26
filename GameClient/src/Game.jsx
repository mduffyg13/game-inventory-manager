
import { useState, useEffect } from 'react';
import GameList from './GameList';

const term = "Game";

function Game() {
  const [data, setData] = useState([]);
  const [maxId, setMaxId] = useState(0);

  useEffect(() => {
    fetchGameData();
  }, []);

  const fetchGameData = () => {
    // Simulate fetching data from API
    const gameData = [
      { id: 1, name: 'ICO', platform: 'PS2' },
      { id: 2, name: 'Yakuza', platform: 'PS2' },
      { id: 3, name: 'Super Mario Sunshine', platform: 'NGC' },
    ];
    setData(gameData);
    setMaxId(Math.max(...gameData.map(x => x.id)));
  };

  const handleCreate = (item) => {
    // Simulate creating item on API
    const newItem = { ...item, id: data.length + 1 };
    setData([...data, newItem]);
    setMaxId(maxId + 1);
  };

  const handleUpdate = (item) => {
    // Simulate updating item on API
    const updatedData = data.map(x => x.id === item.id ? item : x);
    setData(updatedData);
  };

  const handleDelete = (id) => {
    // Simulate deleting item on API
    const updatedData = data.filter(x => x.id !== id);
    setData(updatedData);
  };


  return (
    <div>
      <GameList
        name={term}
        data={data}
        onCreate={handleCreate}
        onUpdate={handleUpdate}
        onDelete={handleDelete}
      />
    </div>
  );
}

export default Game;