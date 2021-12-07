import axios from 'axios';

const URL = 'https://localhost:5001/api/Products/';

const getAll = async () => {
  const response = await axios.get(URL);
  return response.data;
};

const getOne = async (id) => {
  const response = await axios.get(`${URL}${id}`);
  return response.data;
};

export default { getAll, getOne };
