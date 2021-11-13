import { Card } from 'antd';
import './CardBook.scss'
import ModalBookDetail from './ModalBookDetail';
import { useState } from 'react';
const { Meta } = Card;
const CardBook = (props) => {
    const [visible, setVisible] = useState(false);
    return (
        <>
            <Card
                hoverable
                className="card"
                style={{ width: '100%', margin: '10px 0' }}
                cover={<img alt="example" src={props.book.urlImage} />}
                onClick={() => setVisible(true)}
            >
                <Meta title={props.book.name} className="mete" />
            </Card>
            <ModalBookDetail
                visible={visible}
                setVisible={setVisible}
                book={props.book}
                booksRequest={props.booksRequest}
                setBooksRequest={props.setBooksRequest}
            />
        </>
    )
}

export default CardBook;