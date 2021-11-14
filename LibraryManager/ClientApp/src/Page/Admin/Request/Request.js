import { useState, useEffect } from "react";
import { GetRequest, PutRequest } from "../../../Api/RequestApi";
import { Spin, Table, Button } from 'antd';
import { failed, success } from "../../../component/Message";


const Request = () => {
    const [requests, setRequest] = useState([])
    const [isLoading, setisLoading] = useState(false)
    const [rowWasEntered, setRowWasEntered] = useState(null)
    const [reLoading, setReLoading] = useState(false)

    useEffect(() => {
        async function getRequest() {
            setRequest(await GetRequest())
            setisLoading(false);
        }
        getRequest()
    }, [reLoading])

    const handleFunction = async () => {
        const result = await PutRequest({ ...rowWasEntered, status: rowWasEntered.status === "approve" ? "reject" : "approve" })
        if (result.status === 200) {
            await success(rowWasEntered.status === "approve" ? "Reject request" : "Approve request")
            setReLoading(prev => !prev)
        }
        else {
            failed(result)
        }
    }

    const columns = [
        {
            title: 'Id',
            dataIndex: 'id',
        },
        {
            title: 'Who request id',
            dataIndex: 'whoRequestId',
        },
        {
            title: 'Requesting Date ',
            dataIndex: 'requestedDate',
        },
        {
            title: 'Handling Date',
            dataIndex: 'handledDate',
        },
        {
            title: 'Who handle Id',
            dataIndex: 'whoHandleId',
        },
        {
            title: "Status",
            align: 'right',
            size: "small",
            dataIndex: 'status',
            render: (status) => (
                <Button type={status === "approve" ? "danger" : "primary"} onClick={handleFunction}>{status === "approve" ? "Reject" : "Approve"} </Button>
            )

        }
    ];
    if (isLoading) {
        return <Spin size="large" style={{ position: 'absolute', top: '50%', left: '50%', translate: '-50%,-50%' }} />
    }
    return (
        <div>

            <Table
                columns={columns}
                dataSource={requests}
                bordered style={{ margin: '20px 0' }}
                rowKey="id"
                onRow={(record) => {
                    return {
                        onMouseEnter: () => { setRowWasEntered(record) },
                    }
                }}
            />
        </div>
    )
}
export default Request;