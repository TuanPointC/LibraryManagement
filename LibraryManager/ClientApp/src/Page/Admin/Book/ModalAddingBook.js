import { v4 as uuid } from "uuid";
import { Button, Modal, Form, Input, Select } from 'antd';
import { PostBook } from "../../../Api/BookApi";
import { useState } from "react";
import { failed, success } from "../../../component/Message";
const { Option } = Select;
const { TextArea } = Input;
const layout = {
    labelCol: { span: 4 },
    wrapperCol: { span: 24 },
};

const ModalAddingBook = (props) => {
    const [isModalVisible, setIsModalVisible] = useState(false);
    const validateMessages = {
        required: "the field is required!"
    };
    const showModal = () => {
        setIsModalVisible(true);
    };

    const handleCancel = () => {
        setIsModalVisible(false);
    };
    const onFinish = async (values) => {
        var bookClone = { ...values.book, id: uuid(), category: values.book.categoryId[0], categoryId: values.book.categoryId[1] }
        var res = await PostBook(bookClone);
        setIsModalVisible(false);
        if (res.status === 200) {
            await success("Adding book")
            var listBooks = [...props.books]
            listBooks.push(bookClone)
            props.setBooks(listBooks)
        }
        else {
            failed("Adding book")
        }
        console.log(values);
    };

    return (
        <div>
            <Button type="primary" onClick={showModal}>Add Book</Button>
            <Modal title="Create new book" visible={isModalVisible} onCancel={handleCancel} footer={null} >
                <Form {...layout} onFinish={onFinish} validateMessages={validateMessages}>

                    <Form.Item name={['book', 'name']} label="Name" rules={[{ required: true }]}>
                        <Input />
                    </Form.Item>
                    <Form.Item name={['book', 'author']} label="Author" rules={[{ required: true }]}>
                        <Input />
                    </Form.Item>
                    <Form.Item name={['book', 'urlImage']} label="Url Image" rules={[{ required: true }]}>
                        <Input />
                    </Form.Item>
                    <Form.Item name={['book', 'summary']} label="Summary
                    " rules={[{ required: true }]}>
                        <TextArea rows={4} />
                    </Form.Item>

                    <Form.Item name={['book', 'categoryId']} label="Category" rules={[{ required: true }]}>
                        <Select
                            placeholder="Category"
                            allowClear
                        >
                            {props.categories.map((category) => {
                                return (
                                    <Option value={[category.name, category.id]} key={category.id}>{category.name}</Option>
                                )
                            })}
                        </Select>
                    </Form.Item>


                    <Form.Item wrapperCol={{ ...layout.wrapperCol, offset: 20 }}>
                        <Button type="primary" htmlType="submit">
                            Submit
                        </Button>
                    </Form.Item>

                </Form>
            </Modal>
        </div>
    )
}

export default ModalAddingBook