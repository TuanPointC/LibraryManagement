import { v4 as uuid } from "uuid";
import { Button, Modal, Form, Input } from 'antd';
import { PostCategory } from "../../../Api/CategoryApi";
import { useState } from "react";
import { failed,success } from "../../../component/Message";
const layout = {
    labelCol: { span: 4 },
    wrapperCol: { span: 24 },
};

const ModalAddingCategory = (props) => {
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
        var categoryClone = { ...values.category, id: uuid() }
        var res = await PostCategory(categoryClone);
        setIsModalVisible(false);
        if (res.status === 200) {
            await success()
            var listCategories = [...props.categories]
            listCategories.push(categoryClone)
            props.setCategories(listCategories)
        }
        else {
            failed()
        }
    };
    return (
        <div>
            <Button type="primary" onClick={showModal}>Add Category</Button>
            <Modal title="Create new Category" visible={isModalVisible} onCancel={handleCancel} footer={null} >
                <Form {...layout} onFinish={onFinish} validateMessages={validateMessages}>

                    <Form.Item name={['category', 'name']} label="Name" rules={[{ required: true }]}>
                        <Input />
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

export default ModalAddingCategory