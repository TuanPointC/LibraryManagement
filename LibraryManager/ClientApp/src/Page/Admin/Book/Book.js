import { useState, useEffect } from "react";
import { GetBooks } from "../../../Api/BookApi";
import { GetCategories } from "../../../Api/CategoryApi";
import { Spin, Table, Button, Space } from 'antd';
import { Link, useRouteMatch } from "react-router-dom";
import ModalAddingBook from "./ModalAddingBook";
const Book = () => {
    const [books, setBooks] = useState([])
    const [categories, setCategories] = useState([])
    const [isLoading, setisLoading] = useState(false)
    const [rowWasEntered, setRowWasEntered] = useState(null)
    let { url } = useRouteMatch();

    const columns = [
        {
            title: 'Id',
            dataIndex: 'id',
        },
        {
            title: 'Name',
            dataIndex: 'name',
            ellipsis: true,
        },
        {
            title: 'Author',
            dataIndex: 'author',
            ellipsis: true,
        },
        {
            title: 'Url Image',
            dataIndex: 'urlImage',
            ellipsis: true,
        },
        {
            title: 'Summary',
            dataIndex: 'summary',
            ellipsis: true,
        },
        {
            title: 'Category',
            dataIndex: 'categoryId',
            ellipsis: true,
        },
        {
            title: 'Category',
            dataIndex: 'category',
            ellipsis: true,
        },
        {
            title: "Actions",
            with:80,
            align: 'right',
            size: "small",
            render: () => (
                <Space size="large">
                    <Button type="primary"><Link to={`${url}/${rowWasEntered}`}>Edit</Link></Button>
                </Space>
            ),
            
        }
    ];
    useEffect(() => {
        async function getBook() {
            var listCategories = await GetCategories()
            setCategories(listCategories)
            var listBooks = await GetBooks()

            var listBookAddingFeature = listBooks.map((book) => {
                var categoryName = listCategories.find(cate => cate.id === book.categoryId).name
                return { ...book, category: categoryName }
            })
            setBooks(listBookAddingFeature)
            setisLoading(false);
        }
        getBook()
    }, [])
    if (isLoading) {
        return <Spin size="large" style={{ position: 'absolute', top: '50%', left: '50%', translate: '-50%,-50%' }} />
    }
    return (
        <div>

            <ModalAddingBook 
                categories={categories}
                books={books}
                setBooks={setBooks}
            />
            <Table
                columns={columns}
                dataSource={books}
                bordered style={{ margin: '20px 0' }}
                rowKey="id"
                onRow={(record) => {
                    return {
                        onMouseEnter: () => { setRowWasEntered(record.id) },
                    }
                }}
            />
        </div>
    )
}
export default Book;