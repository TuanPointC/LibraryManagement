import { GetCategoryById, DeleteCategoryById, PutCategory } from "../../../Api/CategoryApi";
import { useState, useEffect } from "react"
import { Spin, Form, Button, Input } from 'antd';
import { useParams, useHistory } from "react-router-dom";
import { failed, success } from "../../../component/Message";

const layout = {
    labelCol: { span: 4 },
    wrapperCol: { span: 22 },
};

const UpdateCategory = () => {
    const { id } = useParams();
    const [category, setCategory] = useState(null)
    let history = useHistory();

    const validateMessages = {
        required: "the field is required!"
    };

    useEffect(() => {
        async function getCategory() {
            var categoryClone = await GetCategoryById(id)
            setCategory(categoryClone)
        }
        getCategory()
    }, [id])

    const onFinish = async (values) => {
        try {
            const res = await PutCategory({ ...values.category })
            if (res.status === 200) {
                await success("Updating")
                history.push('/admin/category')
            }
        }
        catch {
            failed("Updating")
        }

    };

    const onDelete = async () => {
        try {
            const res = await DeleteCategoryById(category.id);
            if (res.status === 200) {
                await success("Deleting")
                history.push('/admin/category')
            }
        }
        catch {
            failed("Deleting")
        }
    }

    if (!category) {
        return <Spin size="large" style={{ position: 'absolute', top: '50%', left: '50%', translate: '-50%,-50%' }} />
    }
    return (
        <div>
            <Form {...layout} onFinish={onFinish} validateMessages={validateMessages} style={{ border: '1px solid gray', width: '700px', margin: '20px auto', padding: '3rem', background: 'white' }}>

                <Form.Item name={['category', 'id']} label="Id" initialValue={category.id}>
                    <Input disabled />
                </Form.Item>

                <Form.Item name={['category', 'name']} label="Name" rules={[{ required: true }]} initialValue={category.name}>
                    <Input />
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

export default UpdateCategory