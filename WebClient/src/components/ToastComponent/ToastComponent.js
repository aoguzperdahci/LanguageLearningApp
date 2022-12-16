import React, { useEffect, useRef } from 'react';
import { Toast, ToastContainer } from 'react-bootstrap';
import { useDispatch, useSelector } from 'react-redux';
import { removeNotification } from '../../redux/ToastSlice';

const ToastComponent = () => {

    const notifications = useSelector(state => state.toast);
    const dispatch = useDispatch();
    const preCount = useRef(0);

    useEffect(() => {
        if (notifications.length > preCount.current) {
            preCount.current = notifications.length;
            setTimeout(() => {
                preCount.current--;
                dispatch(removeNotification());
            }, 3000);
        }
    }, [notifications])

    return (
        <>
            <ToastContainer className="p-3" position="bottom-end">
                {notifications.map((notification, index) => (
                    <Toast bg={notification.type} key={1000 + index}>
                        <Toast.Body className="text-white">{notification.message}</Toast.Body>
                    </Toast>
                ))
                }
            </ToastContainer>
        </>
    );
}

export default ToastComponent