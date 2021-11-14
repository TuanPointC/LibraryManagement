import { GetBookById, PutBook, DeleteBookById } from "../../../Api/BookApi";
import { useState, useEffect } from "react"
import { Spin, Form, Button, Input, Select } from 'antd';
import { useParams, useHistory } from "react-router-dom";
import { failed, success } from "../../../component/Message";
import { GetCategories } from "../../../Api/CategoryApi";

const { Option } = Select
const { TextArea } = Input

const layout = {
    labelCol: { span: 4 },
    wrapperCol: { span: 22 },
};

const UpdateBook = () => {
    const { id } = useParams();
    const [book, setBook] = useState(null)
    const [categories, setCategories] = useState([])
    let history = useHistory();

    const validateMessages = {
        required: "the field is required!"
    };
    useEffect(() => {
        async function getBook() {
            var bookClone = await GetBookById(id)
            var listCategories = await GetCategories()
            var categoryName = listCategories.find(cate => cate.id === bookClone.categoryId).name
            setBook({ ...bookClone, category: categoryName })
            setCategories(listCategories)
        }
        getBook()
    }, [id])

    const onFinish = async (values) => {
        var res = await PutBook({ ...values.book, category: values.book.categoryId[0], categoryId: values.book.categoryId[1] })
        if (res.status === 200) {
            await success("Updating Book")
            history.push('/admin/book')
        }
        else {
            await failed(res)
        }

    };

    const onDelete = async () => {

        const res = await DeleteBookById(book.id);
        if (res.status === 200) {
            await success("Deleting Book")
            history.push('/admin/book')
        }
        else {
            failed(res)
        }
    }
    

    if (!book) {
        return <Spin size="large" style={{ position: 'absolute', top: '50%', left: '50%', translate: '-50%,-50%' }} />
    }
    return (
        <div>
            <Form {...layout} onFinish={onFinish} validateMessages={validateMessages} style={{ border: '1px solid gray', width: '700px', margin: '20px auto', padding: '3rem', background: 'white' }}>
                <Form.Item name={['book', 'id']} label="Name" rules={[{ required: true }]} initialValue={book.id}>
                    <Input disabled />
                </Form.Item>
                <Form.Item name={['book', 'name']} label="Name" rules={[{ required: true }]} initialValue={book.name}>
                    <Input />
                </Form.Item>
                <Form.Item name={['book', 'author']} label="Author" rules={[{ required: true }]} initialValue={book.author}>
                    <Input />
                </Form.Item>
                <Form.Item name={['book', 'urlImage']} label="Url Image" rules={[{ required: true }]} initialValue={book.urlImage}>
                    <Input />
                </Form.Item>
                <Form.Item name={['book', 'summary']} label="Summary" rules={[{ required: true }]} initialValue={book.summary}>
                    <TextArea rows={4} />
                </Form.Item>

                <Form.Item name={['book', 'categoryId']} label="Category" rules={[{ required: true }]} initialValue={[book.category, book.categoryId]}>
                    <Select
                    >
                        {categories.map((category) => {
                            return (
                                <Option value={[category.name, category.id]} key={category.id}>{category.name}</Option>
                            )
                        })}
                    </Select>
                </Form.Item>

                <Form.Item wrapperCol={{ ...layout.wrapperCol, offset: 16 }}>
                    <div style={{ display: 'flex' }}>
                        <Button type="primary" htmlType="submit" style={{ marginRight: '2rem' }}>
                            Save
                        </Button>
                        <Button type="danger" onClick={onDelete}>
                            Delete
                        </Button>
                    </div>
                </Form.Item>

            </Form>
        </div>
    )
}

export default UpdateBook