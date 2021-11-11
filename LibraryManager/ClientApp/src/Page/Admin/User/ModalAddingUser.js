import { v4 as uuid } from "uuid";
import { Button, Modal, Form, Input, Switch } from 'antd';
import { PostUser } from "../../../Api/UserApi";
import { useState } from "react";
import { failed, success } from "../../../component/Message";
const layout = {
    labelCol: { span: 4 },
    wrapperCol: { span: 24 },
};

const ModalAddingUser = (props) => {
    const [isModalVisible, setIsModalVisible] = useState(false);
    const validateMessages = {
        required: "the field is required!",
        types: {
            email: 'email is not a valid email!',
        }
    };
    const showModal = () => {
        setIsModalVisible(true);
    };

    const handleCancel = () => {
        setIsModalVisible(false);
    };
    const onFinish = async (values) => {
        var userClone = { ...values.user, role: values.user.role ? 'admin' : 'normal', id: uuid() }
        try {
            var res = await PostUser(userClone);
            setIsModalVisible(false);
            if (res.status === 200) {
                await success("Adding user")
                var listUser = [...props.user]
                listUser.push(res.data)
                props.setUser(listUser)
            }

        }
        catch {
            failed("Adding user")
        }
    };
    return (
        <div>
            <Button type="primary" onClick={showModal}>Add User</Button>
            <Modal title="Create new user" visible={isModalVisible} onCancel={handleCancel} footer={null} >
                <Form {...layout} onFinish={onFinish} validateMessages={validateMessages}>

                    <Form.Item name={['user', 'name']} label="Name" rules={[{ required: true }]}>
                        <Input />
                    </Form.Item>
                    <Form.Item name={['user', 'email']} label="Email" rules={[{ type: 'email', required: true }]}>
                        <Input />
                    </Form.Item>
                    <Form.Item name={['user', 'password']} label="Password" rules={[{ required: true, min: 8 }]}>
                        <Input.Password />
                    </Form.Item>
                    <Form.Item label="Admin" valuePropName="checked" name={['user', 'role']}>
                        <Switch />
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

export default ModalAddingUser