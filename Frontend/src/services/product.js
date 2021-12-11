import axios from 'axios';

const URL = 'https://localhost:44310/api/Products/';

const getAll = async () => {
  const response = await axios.get(URL);
  return response.data;
};

const getOne = async (id) => {
  const response = await axios.get(`${URL}${id}`);
  return response.data;
};

const getFourNewest = async () => {
  const response = await axios.get(URL + 'limit=4');
  return response.data;
};

const getFourMostPopular = async () => {
  const response = await axios.get(URL + 'popular=4');
  return response.data;
};

const getWithCategory = async (category) => {
  const response = await axios.get(URL + 'category=' + { category });
  return response.data;
};

export default { getAll, getOne, getFourNewest, getFourMostPopular, getWithCategory };
