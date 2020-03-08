﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tensorflow;
using Buffer = System.Buffer;

namespace TensorFlowNET.UnitTest
{
    public class CApiTest
    {
        protected TF_Code TF_OK = TF_Code.TF_OK;
        protected TF_DataType TF_FLOAT = TF_DataType.TF_FLOAT;

        protected void EXPECT_TRUE(bool expected, string msg = "")
            => Assert.IsTrue(expected, msg);

        protected void EXPECT_EQ(object expected, object actual, string msg = "")
            => Assert.AreEqual(expected, actual, msg);

        protected void CHECK_EQ(object expected, object actual, string msg = "")
            => Assert.AreEqual(expected, actual, msg);

        protected void EXPECT_NE(object expected, object actual, string msg = "")
            => Assert.AreNotEqual(expected, actual, msg);

        protected void EXPECT_GE(int expected, int actual, string msg = "")
            => Assert.IsTrue(expected >= actual, msg);

        protected void ASSERT_EQ(object expected, object actual, string msg = "")
            => Assert.AreEqual(expected, actual, msg);

        protected void ASSERT_TRUE(bool condition, string msg = "")
            => Assert.IsTrue(condition, msg);

        protected OperationDescription TF_NewOperation(Graph graph, string opType, string opName)
            => c_api.TF_NewOperation(graph, opType, opName);

        protected void TF_AddInput(OperationDescription desc, TF_Output input)
            => c_api.TF_AddInput(desc, input);

        protected Operation TF_FinishOperation(OperationDescription desc, Status s)
            => c_api.TF_FinishOperation(desc, s);

        protected void TF_SetAttrTensor(OperationDescription desc, string attrName, Tensor value, Status s)
            => c_api.TF_SetAttrTensor(desc, attrName, value, s);

        protected void TF_SetAttrType(OperationDescription desc, string attrName, TF_DataType dtype)
            => c_api.TF_SetAttrType(desc, attrName, dtype);

        protected void TF_SetAttrBool(OperationDescription desc, string attrName, bool value)
            => c_api.TF_SetAttrBool(desc, attrName, value);

        protected TF_DataType TFE_TensorHandleDataType(IntPtr h)
            => c_api.TFE_TensorHandleDataType(h);

        protected int TFE_TensorHandleNumDims(IntPtr h, IntPtr status)
            => c_api.TFE_TensorHandleNumDims(h, status);

        protected TF_Code TF_GetCode(Status s)
            => s.Code;

        protected TF_Code TF_GetCode(IntPtr s)
            => c_api.TF_GetCode(s);

        protected string TF_Message(IntPtr s)
            => c_api.StringPiece(c_api.TF_Message(s));

        protected IntPtr TF_NewStatus()
            => c_api.TF_NewStatus();

        protected void TF_DeleteStatus(IntPtr s)
            => c_api.TF_DeleteStatus(s);

        protected IntPtr TF_TensorData(IntPtr t)
            => c_api.TF_TensorData(t);

        protected ulong TF_TensorByteSize(IntPtr t)
            => c_api.TF_TensorByteSize(t);

        protected void TFE_OpAddInput(IntPtr op, IntPtr h, IntPtr status)
            => c_api.TFE_OpAddInput(op, h, status);

        protected void TFE_OpSetAttrType(IntPtr op, string attr_name, TF_DataType value)
            => c_api.TFE_OpSetAttrType(op, attr_name, value);

        protected void TFE_OpSetAttrShape(IntPtr op, string attr_name, long[] dims, int num_dims, IntPtr out_status)
            => c_api.TFE_OpSetAttrShape(op, attr_name, dims, num_dims, out_status);

        protected void TFE_OpSetAttrString(IntPtr op, string attr_name, string value, uint length)
            => c_api.TFE_OpSetAttrString(op, attr_name, value, length);

        protected IntPtr TFE_NewOp(IntPtr ctx, string op_or_function_name, IntPtr status)
            => c_api.TFE_NewOp(ctx, op_or_function_name, status);

        protected void TFE_Execute(IntPtr op, IntPtr[] retvals, ref int num_retvals, IntPtr status)
            => c_api.TFE_Execute(op, retvals, ref num_retvals, status);

        protected IntPtr TFE_NewContextOptions()
            => c_api.TFE_NewContextOptions();

        protected void TFE_DeleteContext(IntPtr t)
            => c_api.TFE_DeleteContext(t);

        protected IntPtr TFE_NewContext(IntPtr opts, IntPtr status)
            => c_api.TFE_NewContext(opts, status);

        protected void TFE_DeleteContextOptions(IntPtr opts)
            => c_api.TFE_DeleteContextOptions(opts);

        protected void TFE_DeleteTensorHandle(IntPtr h)
            => c_api.TFE_DeleteTensorHandle(h);

        protected void TFE_DeleteOp(IntPtr op)
            => c_api.TFE_DeleteOp(op);

        protected void TFE_DeleteExecutor(IntPtr executor)
            => c_api.TFE_DeleteExecutor(executor);

        protected IntPtr TFE_ContextGetExecutorForThread(IntPtr ctx)
            => c_api.TFE_ContextGetExecutorForThread(ctx);

        protected void TFE_ExecutorWaitForAllPendingNodes(IntPtr executor, IntPtr status)
            => c_api.TFE_ExecutorWaitForAllPendingNodes(executor, status);

        protected IntPtr TFE_TensorHandleResolve(IntPtr h, IntPtr status)
            => c_api.TFE_TensorHandleResolve(h, status);

        protected string TFE_TensorHandleDeviceName(IntPtr h, IntPtr status)
            => c_api.StringPiece(c_api.TFE_TensorHandleDeviceName(h, status));

        protected string TFE_TensorHandleBackingDeviceName(IntPtr h, IntPtr status)
            => c_api.StringPiece(c_api.TFE_TensorHandleBackingDeviceName(h, status));

        protected IntPtr TFE_ContextListDevices(IntPtr ctx, IntPtr status)
            => c_api.TFE_ContextListDevices(ctx, status);

        protected int TF_DeviceListCount(IntPtr list)
            => c_api.TF_DeviceListCount(list);

        protected string TF_DeviceListType(IntPtr list, int index, IntPtr status)
            => c_api.StringPiece(c_api.TF_DeviceListType(list, index, status));

        protected string TF_DeviceListName(IntPtr list, int index, IntPtr status)
            => c_api.StringPiece(c_api.TF_DeviceListName(list, index, status));

        protected void TF_DeleteDeviceList(IntPtr list)
            => c_api.TF_DeleteDeviceList(list);

        protected IntPtr TFE_TensorHandleCopyToDevice(IntPtr h, IntPtr ctx, string device_name, IntPtr status)
            => c_api.TFE_TensorHandleCopyToDevice(h, ctx, device_name, status);

        protected void TFE_OpSetDevice(IntPtr op, string device_name, IntPtr status)
            => c_api.TFE_OpSetDevice(op, device_name, status);

        protected unsafe void memcpy<T>(T* dst, void* src, ulong size)
            where T : unmanaged
        {
            Buffer.MemoryCopy(src, dst, size, size);
        }

        protected unsafe void memcpy<T>(void* dst, T* src, ulong size)
            where T : unmanaged
        {
            Buffer.MemoryCopy(src, dst, size, size);
        }

        protected unsafe void memcpy(void * dst, IntPtr src, ulong size)
        {
            Buffer.MemoryCopy(src.ToPointer(), dst, size, size);
        }

        protected unsafe void memcpy<T>(T[] dst, IntPtr src, ulong size)
            where T : unmanaged
        {
            fixed (void* p = &dst[0])
                Buffer.MemoryCopy(src.ToPointer(), p, size, size);
        }

        protected unsafe void memcpy<T>(T[] dst, IntPtr src, long size)
            where T : unmanaged
        {
            fixed (void* p = &dst[0])
                Buffer.MemoryCopy(src.ToPointer(), p, size, size);
        }

        protected unsafe void memcpy<T>(IntPtr dst, T[] src, ulong size)
            where T : unmanaged
        {
            fixed (void* p = &src[0])
                Buffer.MemoryCopy(p, dst.ToPointer(), size, size);
        }

        protected unsafe void memcpy<T>(IntPtr dst, T[] src, long size)
            where T: unmanaged
        {
            fixed (void* p = &src[0])
                Buffer.MemoryCopy(p, dst.ToPointer(), size, size);
        }
    }
}
