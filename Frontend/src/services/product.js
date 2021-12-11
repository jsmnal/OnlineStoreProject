import axios from 'axios';
import config from '../utils/config';

const URL = `${config.DEV_BACKEND_URL}/api/Products/`;

const getAll = async () => {
  const response = await axios.get(URL);
  return response.data;
};

const getOne = async (id) => {
  const response = await axios.get(`${URL}${id}`);
  return response.data;
};

export default { getAll, getOne };
