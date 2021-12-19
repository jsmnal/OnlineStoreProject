import { v4 as uuidv4 } from 'uuid';

const addItemToCart = (item) => {
  const isCart = window.localStorage.getItem('cart');
  if (isCart) {
    const cart = JSON.parse(isCart);
    item.localStorageUuid = uuidv4();
    cart.push(item);
    window.localStorage.setItem('cart', JSON.stringify(cart));
  } else {
    item.localStorageUuid = uuidv4();
    window.localStorage.setItem('cart', JSON.stringify([item]));
  }
};

const getItemsFromCart = () => {
  const isCart = window.localStorage.getItem('cart');
  return isCart ? JSON.parse(isCart) : null;
};

const removeItemFromCart = (id) => {
  const isCart = window.localStorage.getItem('cart');
  if (isCart) {
    const cart = JSON.parse(isCart);
    console.log(cart);
    const filteredCart = cart.filter((product) => {
      return product.localStorageUuid !== id;
    });
    window.localStorage.setItem('cart', JSON.stringify(filteredCart));
  }
};

export default { addItemToCart, getItemsFromCart, removeItemFromCart };
