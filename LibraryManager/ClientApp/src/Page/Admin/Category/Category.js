import axios from "axios";
import { useState, useEffect } from "react";
import { Table, Spin } from 'antd';

const columns = [
    {
        title: 'Id',
        dataIndex: 'id',
    },
    {
        title: 'Name',
        dataIndex: 'name',
    },
    {
        title: 'Number Books',
        dataIndex: 'books',
        render: books => {
            if (books) {
                books.map(b => b.length)
            }
            else{
                return 0
            }
        }
    },
];

const Category = () => {
    const [categories, setCategories] = useState([])
    useEffect(() => {
        axios.get("/api/category")
            .then((res) => {
                setCategories(res.data);
            })
    }, [])

    if (categories.length === 0) {
        return <Spin size="large" style={{ position: 'absolute', top: '50%', left: '50%', translate: '-50%,-50%' }} />
    }
    return (
        <Table columns={columns} dataSource={categories} bordered style={{ margin: '20px 0' }} pagination={false} rowKey="id" />
    )
}
export default Category;