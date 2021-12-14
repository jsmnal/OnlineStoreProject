import { Card } from 'react-bootstrap';
import { Link } from 'react-router-dom';

const ImageCard = ({ name, price, image, id }) => {
  return (
    <Card
      style={{
        width: '225px',
        maxHeight: '500px',
        margin: '20px',
        boxShadow: '0 0 2px 2px #765d3a',
      }}
    >
      <Card.Link as={Link} to={`/products/${id}`}>
        <Card.Img
          style={{ marginTop: '10px', height: '200px' }}
          variant="top"
          src={image}
          title="Click the image to take a look"
        />
      </Card.Link>
      <Card.Body>
        <Card.Title>{name}</Card.Title>
        <Card.Title> Price: {price}</Card.Title>
      </Card.Body>
    </Card>
  );
};

export default ImageCard;
