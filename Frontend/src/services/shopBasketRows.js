import axios from 'axios';
import config from '../utils/config';

const URL = `${config.DEV_BACKEND_URL}/api/ShopBasketRows/`;

const createBasketRow = async (product) => {
  const response = await axios.post(URL, product, { withCredentials: true });
  return response.data;
};

const getCurrentShopBasket = async () => {
  const response = await axios.get(`${URL}currentShopBasket/`, {
    withCredentials: true,
  });
  return response.data;
};

const deleteBasketRow = async (id) => {
  const response = await axios.delete(`${URL}${id}`, {
    withCredentials: true,
  });
  return response.data;
};

export default { createBasketRow, getCurrentShopBasket, deleteBasketRow };
