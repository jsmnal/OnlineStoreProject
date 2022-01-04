import axios from 'axios';
import config from '../utils/config';

const URL = `${config.DEV_BACKEND_URL}/api/user/`;

const createUser = async (user) => {
  const response = await axios.post(URL, user, { withCredentials: true });
  return response.data;
};

export default { createUser };
