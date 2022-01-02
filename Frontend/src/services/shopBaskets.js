import axios from 'axios';
import config from '../utils/config';

const URL = `${config.DEV_BACKEND_URL}/api/ShopBaskets/`;

const createShopBasket = async (basket) => {
  const response = await axios.post(URL, basket, { withCredentials: true });
  return response.data;
};

const updateShopBasket = async (id, basket) => {
  const response = await axios.put(`${URL}${id}`, basket, {
    withCredentials: true,
  });
  return response.data;
};

export default { createShopBasket, updateShopBasket };
