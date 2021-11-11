import { GetBooks } from '../../../Api/BookApi'
import { GetCategories } from '../../../Api/CategoryApi'
import { useState, useEffect } from 'react';
import { Spin, Row, Col } from 'antd'
import './Home.scss'
import CardBook from './CardBook';


const Home = () => {
    const [books, setBooks] = useState([])
    const [categories, setCategories] = useState([])
    const [isLoading, setisLoading] = useState(true)

    useEffect(() => {
        async function loadData() {
            setCategories(await GetCategories())
            setBooks(await GetBooks())
            setisLoading(false);
        }
        loadData()

    }, [])
    if (isLoading) {
        return <Spin size="large" style={{ position: 'absolute', top: '50%', left: '50%', translate: '-50%,-50%' }} />
    }
    return (

        <div className="home">
            {categories.map((category) => (
                <div className="list-category" key={category.id}>
                    <div className="category" >{category.name}</div>

                    <Row gutter={16}>
                        {
                            books.filter(book => book.categoryId === category.id).map(book => {
                                return (
                                    <Col
                                        className="gutter-row"
                                        key={book.id}
                                        xs={{ span: 24, offset: 0 }}
                                        md={{ span: 12, offset: 0 }}
                                        lg={{ span: 4, offset: 0 }}
                                    >
                                        <CardBook book={book} />
                                        

                                    </Col>
                                )
                            })}
                    </Row>

                </div>
            ))}
        </div>

    )
}
export default Home;