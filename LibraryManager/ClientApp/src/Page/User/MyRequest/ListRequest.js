import { Table, Space, Button } from 'antd';
import { useState,useEffect } from 'react';
import { GetRequest } from '../../../Api/RequestApi';
const columns = [
    {
        title: 'Name',
        dataIndex: 'name',
        ellipsis: true,
    },
    {
        title: 'Author',
        dataIndex: 'author',
        ellipsis: true,
    },
    {
        title: "Actions",
        with: 80,
        align: 'right',
        size: "small",
        render: () => (
            <Space size="large">
                <Button type="danger">Delete</Button>
            </Space>
        ),

    }
];
const ListRequest = () => {
    const [requests,setListRequest] = useState([])
    useEffect(()=>{

    },[])
    return (
        <div>
            <h1>List Requests</h1>
            <Table
                columns={columns}
                dataSource={requests}
                bordered style={{ margin: '20px 0' }}
                rowKey="id"
            />
        </div>
    )
}

export default ListRequest