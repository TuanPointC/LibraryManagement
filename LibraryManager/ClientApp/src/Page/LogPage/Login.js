import { Form, Input, Button } from 'antd';
import { Redirect } from 'react-router';
import { PostLogin } from '../../Api/LoginApi';
import { useState } from 'react'
import { success, failed } from '../../component/Message';
const Login = () => {
    const [canAccess, setCanAccess] = useState(false)

    const onFinish = async (values) => {
        try {
            const res = await PostLogin(values)
            if (res.status === 200) {
                await success("login")
                setCanAccess(true)
                localStorage.setItem('token', res.data.token)
                localStorage.setItem('userName', res.data.userName)
                localStorage.setItem('userId', res.data.userId)
                localStorage.setItem('userEmail', res.data.userEmail)
            }
        }
        catch {
            await failed("login")
        }
    };

    const onFinishFailed = (errorInfo) => {

    };

    if (canAccess) {
        return (
            <Redirect to='/' />
        )
    }
    return (
        <div style={{ width: '600px', position:'absolute',top:'50%',left:'50%',transform:'translate(-50%,-50%)',border:'1px solid gray',padding:'100px' }}>
            <h1 style={{textAlign:'center'}}>Login</h1>
            <Form
                name="basic"
                labelCol={{ span: 0, }}
                wrapperCol={{ span: 0, }}
                initialValues={{ remember: true, }}
                onFinish={onFinish}
                onFinishFailed={onFinishFailed}
                autoComplete="off"
            >
                <Form.Item
                    label="Username"
                    name="name"
                    rules={[{ required: true, message: 'Please input your username!', },]}
                >
                    <Input />
                </Form.Item>

                <Form.Item
                    label="Password"
                    name="password"
                    rules={[{ required: true, message: 'Please input your password!', },]}
                >
                    <Input.Password />
                </Form.Item>

                <Form.Item
                    wrapperCol={{ offset: 19 }}
                >
                    <Button type="primary" htmlType="submit">
                        Submit
                    </Button>
                </Form.Item>
            </Form>
        </div>

    )
}
export default Login