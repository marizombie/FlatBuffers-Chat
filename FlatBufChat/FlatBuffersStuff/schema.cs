// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

using global::System;
using global::System.Collections.Generic;
using global::FlatBuffers;

public struct MessageTable : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_1_12_0(); }
  public static MessageTable GetRootAsMessageTable(ByteBuffer _bb) { return GetRootAsMessageTable(_bb, new MessageTable()); }
  public static MessageTable GetRootAsMessageTable(ByteBuffer _bb, MessageTable obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public MessageTable __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public string User { get { int o = __p.__offset(4); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetUserBytes() { return __p.__vector_as_span<byte>(4, 1); }
#else
  public ArraySegment<byte>? GetUserBytes() { return __p.__vector_as_arraysegment(4); }
#endif
  public byte[] GetUserArray() { return __p.__vector_as_array<byte>(4); }
  public string Text { get { int o = __p.__offset(6); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetTextBytes() { return __p.__vector_as_span<byte>(6, 1); }
#else
  public ArraySegment<byte>? GetTextBytes() { return __p.__vector_as_arraysegment(6); }
#endif
  public byte[] GetTextArray() { return __p.__vector_as_array<byte>(6); }

  public static Offset<MessageTable> CreateMessageTable(FlatBufferBuilder builder,
      StringOffset userOffset = default(StringOffset),
      StringOffset textOffset = default(StringOffset)) {
    builder.StartTable(2);
    MessageTable.AddText(builder, textOffset);
    MessageTable.AddUser(builder, userOffset);
    return MessageTable.EndMessageTable(builder);
  }

  public static void StartMessageTable(FlatBufferBuilder builder) { builder.StartTable(2); }
  public static void AddUser(FlatBufferBuilder builder, StringOffset userOffset) { builder.AddOffset(0, userOffset.Value, 0); }
  public static void AddText(FlatBufferBuilder builder, StringOffset textOffset) { builder.AddOffset(1, textOffset.Value, 0); }
  public static Offset<MessageTable> EndMessageTable(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<MessageTable>(o);
  }
};

