import { Table, Space, Button } from 'antd';
import ListRequest from './ListRequest';
import { v4 as uuid } from "uuid";
import { PostRequest } from '../../../Api/RequestApi';
import { useState } from 'react';
import { success, failed } from '../../../component/Message';

const MyRequestContainer = (props) => {
    const [indexRow, setIndexRow] = useState(0)
    const deleteHandle = () => {
        var booksRequestClone = props.booksRequest
        booksRequestClone.splice(indexRow, 1)
        props.setBooksRequest([...booksRequestClone])
    }
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
                    <Button type="danger" onClick={deleteHandle}>Delete</Button>
                </Space>
            ),

        }
    ];
    const BorrowAll = async () => {
        let dateTime = new Date()
        const listRequests = {
            id: uuid(),
            whoRequestId: localStorage.getItem("userId"),
            requestedDate: dateTime,
            status: 'pending',
            listBooks: props.booksRequest
        }
        var res = await PostRequest(listRequests)
        if (res.status === 200) {
            success("Creat borrowing request")
        }
        else {
            failed(res)
        }

    }

    return (
        <div>
            <h1>List Temporary requests</h1>
            <Button type="primary" onClick={BorrowAll} disabled={props.booksRequest.length===0}>Borrow All</Button>
            <Table
                columns={columns}
                dataSource={props.booksRequest}
                bordered style={{ margin: '20px 0' }}
                rowKey="id"
                onRow={(record, rowIndex) => {
                    return {
                        onMouseEnter: () => setIndexRow(rowIndex),
                    }
                }}
            />
            <ListRequest />
        </div>
    )
}
export default MyRequestContainer;