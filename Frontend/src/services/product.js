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

const getNewest = async (limit) => {
  const response = await axios.get(`${URL}limit=${limit}`);
  return response.data;
};

const getMostPopular = async (limit) => {
  const response = await axios.get(`${URL}popular=${limit}`);
  return response.data;
};

const getWithCategory = async (category) => {
  const response = await axios.get(`${URL}category=${category}`);
  return response.data;
};

export default { getAll, getOne, getNewest, getMostPopular, getWithCategory };
