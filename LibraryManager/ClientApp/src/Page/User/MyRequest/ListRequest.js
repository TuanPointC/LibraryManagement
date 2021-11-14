import { Table, Tag } from 'antd';
import { useState, useEffect } from 'react';
import { GetRequestUserId } from '../../../Api/RequestApi';
const setStatus =(status)=>{
    if(status==='approve'){
        return {
            color:'#87d068',
            text:'Approve'
        }
    }
    else if(status==="pending"){
        return {
            color:'#2db7f5',
            text:'Pending'
        }
    }
    else{
        return {
            color:'#f50',
            text:'Reject'
        }
    }
}
const columns = [
    {
        title: 'Requesting Date ',
        dataIndex: 'requestedDate',
    },
    {
        title: 'Book',
        dataIndex: 'bookName',
    },
    {
        title: "Status",
        dataIndex: 'status',
        render: (status) => (
            <Tag color={setStatus(status).color}>{setStatus(status).text}</Tag>
        )
    }
];
const ListRequest = () => {
    const [requests, setListRequest] = useState([])
    useEffect(() => {
        async function getRequest() {
            if (localStorage.getItem("userId")) {
                setListRequest(await GetRequestUserId(localStorage.getItem("userId")))
            }
        }
        getRequest()
    }, [])

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