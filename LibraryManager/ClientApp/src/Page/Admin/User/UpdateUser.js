import { GetUserById, PutUser, DeleteUserById } from "../../../Api/UserApi"
import { useState, useEffect } from "react"
import { Spin, Form, Button, Input, Switch } from 'antd';
import { useParams, useHistory } from "react-router-dom";
import { failed, success } from "../../../component/Message";

const layout = {
    labelCol: { span: 4 },
    wrapperCol: { span: 22 },
};

const UpdateUser = () => {
    const { id } = useParams();
    const [user, setUser] = useState(null)
    let history = useHistory();

    const validateMessages = {
        required: "the field is required!",
        types: {
            email: 'email is not a valid email!',
        }
    };
    useEffect(() => {
        async function getUser() {
            var userClone = await GetUserById(id)
            setUser(userClone)
        }
        getUser()
    }, [id])

    const onFinish = async (values) => {
        try {
            const res = await PutUser({ ...values.user, role: values.role ? 'admin' : 'normal' })
            if (res.status === 200) {
                await success("Updating")
                history.push('/admin/user')
            }

        }
        catch {
            failed("Updating")
        }
    };

    const onDelete = async () => {
        try {
            const res = await DeleteUserById(user.id);
            if (res.status === 200) {
                await success("Deleting")
                history.push('/admin/user')
            }
        }
        catch {
            await failed("Deleting")
        }



    }

    if (!user) {
        return <Spin size="large" style={{ position: 'absolute', top: '50%', left: '50%', translate: '-50%,-50%' }} />
    }
    return (
        <div>
            <Form {...layout} onFinish={onFinish} validateMessages={validateMessages} style={{ border: '1px solid gray', width: '700px', margin: '20px auto', padding: '3rem', background: 'white' }}>

                <Form.Item name={['user', 'id']} label="Id" initialValue={user.id}>
                    <Input disabled />
                </Form.Item>

                <Form.Item name={['user', 'name']} label="Name" rules={[{ required: true }]} initialValue={user.name}>
                    <Input />
                </Form.Item>
                <Form.Item name={['user', 'email']} label="Email" rules={[{ type: 'email', required: true }]} initialValue={user.email}>
                    <Input />
                </Form.Item>
                <Form.Item name={['user', 'password']} label="Password" rules={[{ required: true, min: 8 }]} initialValue={user.password}>
                    <Input.Password />
                </Form.Item>
                <Form.Item label="Admin" valuePropName="checked" name={['user', 'role']} initialValue={user.role === 'admin' ? true : false}>
                    <Switch />
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

export default UpdateUser