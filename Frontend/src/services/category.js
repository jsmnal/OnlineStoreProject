import axios from 'axios';
import config from '../utils/config';

const URL = `${config.DEV_BACKEND_URL}/api/Categories/`;

const getAll = async () => {
  const response = await axios.get(URL);
  return response.data;
};

export default { getAll };
