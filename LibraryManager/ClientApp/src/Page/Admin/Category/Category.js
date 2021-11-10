import { useState, useEffect } from "react";
import { GetCategories } from "../../../Api/CategoryApi";
import { Spin, Table, Button, Space } from 'antd';
import { Link, useRouteMatch } from "react-router-dom";
import ModalAddingCategory from "./ModalAddingCategory";


const Category = () => {
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
        },
        {
            title: "Actions",
            align: 'right',
            size: "small",
            render: () => (
                <Space size="large">
                    <Button type="primary"><Link to={`${url}/${rowWasEntered}`}>Edit</Link></Button>
                </Space>
            )

        }
    ];
    useEffect(() => {
        async function getCategories() {
            setCategories(await GetCategories())
            setisLoading(false);
        }
        getCategories()
    }, [])

    if (isLoading) {
        return <Spin size="large" style={{ position: 'absolute', top: '50%', left: '50%', translate: '-50%,-50%' }} />
    }
    return (
        <div>
            <ModalAddingCategory
                categories={categories}
                setCategories={setCategories}
            />
            <Table
                columns={columns}
                dataSource={categories}
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
export default Category;