import { Card } from 'react-bootstrap';
import { Link } from 'react-router-dom';

const ImageCard = ({ name, price, image, id }) => {
  return (
    <Card
      style={{
        width: '200px',
        margin: '20px',
        boxShadow: '0 0 2px 2px #765d3a',
      }}
    >
      <Link to={`/products/${id}`}>
        <Card.Img style={{ marginTop: '10px' }} variant="top" src={image} />
        <Card.Body>
          <Card.Title>{name}</Card.Title>
          <Card.Title> Price: {price}</Card.Title>
        </Card.Body>
      </Link>
    </Card>
  );
};

export default ImageCard;
