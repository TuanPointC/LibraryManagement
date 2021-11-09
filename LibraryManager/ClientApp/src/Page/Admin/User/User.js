import { useState, useEffect } from "react";
import { GetUsers,PostUser } from "../../../Api/UserApi";
import { Spin, Table, Button, Modal, Form, Input, Switch } from 'antd';

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
        title: 'Email',
        dataIndex: 'email',
    },
    {
        title: 'Password',
        dataIndex: 'password',
    },
    {
        title: 'Role',
        dataIndex: 'role',
    },

];
const layout = {
    labelCol: { span: 4 },
    wrapperCol: { span: 24 },
};

const User = () => {
    const [user, setUser] = useState([])
    const [isLoading, setisLoading] = useState(false)
    const [isModalVisible, setIsModalVisible] = useState(false);

    const validateMessages = {
        required: "the field is required!",
        types: {
            email: 'email is not a valid email!',
        }
    };
    useEffect(() => {
        async function getUser() {
            setUser(await GetUsers())
            setisLoading(false);
        }
        getUser()

    }, [])
    const showModal = () => {
        setIsModalVisible(true);
    };

    const handleCancel = () => {
        setIsModalVisible(false);
    };

    const onFinish = (values) => {
        console.log(values.user)
        var userClone ={...values.user,role:values.user.role?'admin':'normal'}
        PostUser(userClone);
    };

    if (isLoading) {
        return <Spin size="large" style={{ position: 'absolute', top: '50%', left: '50%', translate: '-50%,-50%' }} />
    }
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
                    <Form.Item name={['user', 'password']} label="Password" rules={[{ required: true }]}>
                        <Input.Password />
                    </Form.Item>
                    <Form.Item label="Admin" valuePropName="checked" name={['user', 'role']}>
                        <Switch />
                    </Form.Item>

                    <Form.Item wrapperCol={{ ...layout.wrapperCol, offset: 16 }}>
                        <Button type="primary" htmlType="submit">
                            Submit
                        </Button>
                    </Form.Item>

                </Form>
            </Modal>

            <Table columns={columns} dataSource={user} bordered style={{ margin: '20px 0' }} pagination={false} rowKey="id" />
        </div>
    )
}
export default User;