import { Container, Row } from 'react-bootstrap';
import {useState, useEffect} from 'react';
import ImageCard from './ImageCard';
import axios from 'axios';

const ImageCardRow = () => {
    
    useEffect(() => {
        getProducts();
    }, [])
    
    const [products, setProducts] = useState([]);
    const [loading, setLoading] = useState(false);

    const getProducts = async () => {
        try {
        const res = await axios.get('https://localhost:44310/api/Products/');
            setProducts(res.data);
            setLoading(true);
        } catch(err) {
            alert(err.message);
        }
    }
    return (
    <Container style={{'marginTop':'20px'}} className='d-flex justify-content-center'>
        <Row>
            {loading && products.map((product) => (
                <ImageCard key={product.id} image={'https://localhost:44310/images/' + product.imagePath} name={product.name} price={product.price}/> 
            ))}
        </Row>
    </Container>
    )
}

export default ImageCardRow